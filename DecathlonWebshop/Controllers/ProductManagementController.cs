using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using DecathlonWebshop.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "DeleteProduct")]
    public class ProductManagementController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductManagementController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var product = _productRepository.AllProducts.OrderBy(p => p.Id);
            return View(product);
        }

        public IActionResult AddProduct()
        {
            var categories = _categoryRepository.AllCategories;
            var productEditViewModel = new ProductEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().Id
            };
            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductEditViewModel productEditViewModel)
        {
            //custom validation rules
            if (ModelState.GetValidationState("Product.Price") == ModelValidationState.Valid && productEditViewModel.Product.Price < 0)
                ModelState.AddModelError(nameof(productEditViewModel.Product.Price), "The price must be higher than 0");

            if (productEditViewModel.Product.IsProductOfTheWeek && !productEditViewModel.Product.InStock)
                ModelState.AddModelError(nameof(productEditViewModel.Product.IsProductOfTheWeek), "Only products in stock can be a product of the week");

            //Basic validation
            if (ModelState.IsValid)
            {
                productEditViewModel.Product.CategoryId = productEditViewModel.CategoryId;
                _productRepository.CreateProduct(productEditViewModel.Product);
                return RedirectToAction("Index");
            }
            return View(productEditViewModel);
        }

        public IActionResult EditProduct(int productId)
        {
            var categories = _categoryRepository.AllCategories;

            var product = _productRepository.AllProducts.FirstOrDefault(p => p.Id == productId);

            var productEditViewModel = new ProductEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                Product = product,
                CategoryId = product.CategoryId
            };

            var item = productEditViewModel.Categories.FirstOrDefault(c => c.Value == product.CategoryId.ToString());
            item.Selected = true;

            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductEditViewModel productEditViewModel)
        {
            productEditViewModel.Product.CategoryId = productEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(productEditViewModel.Product);
                return RedirectToAction("Index");
            }
            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var product = _productRepository.AllProducts.FirstOrDefault(p => p.Id == productId);
            _productRepository.DeleteProduct(product);

           return RedirectToAction("Index");
        }
    }
}
