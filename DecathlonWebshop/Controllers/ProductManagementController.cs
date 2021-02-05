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

        public async Task<ViewResult> Index()
        {
            var product = await _productRepository.GetProductsAsync();
            product.OrderBy(p => p.Id);
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
        public async Task<IActionResult> AddProduct(ProductEditViewModel productEditViewModel)
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
                await _productRepository.CreateProductAsync(productEditViewModel.Product);
                return RedirectToAction("Index");
            }
            return View(productEditViewModel);
        }

        public async Task<IActionResult> EditProduct(int productId)
        {
            var categories = _categoryRepository.AllCategories;

            var product = await _productRepository.GetProductByIdAsync(productId);

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
        public async Task<IActionResult> EditProduct(ProductEditViewModel productEditViewModel)
        {
            productEditViewModel.Product.CategoryId = productEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProductAsync(productEditViewModel.Product);
                return RedirectToAction("Index");
            }
            return View(productEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            await _productRepository.DeleteProductAsync(product);

            return RedirectToAction("Index");
        }

        //Remote Validation
        //[AcceptVerbs "Get","Post"]
        public async Task<IActionResult> CheckIfProductNameAlreadyExists([Bind(Prefix = "Product.Name")] string name)
        {
            var product = await _productRepository.GetProductByNameAsync(name);
            return product == null ? Json(true) : Json("This product name is already taken");
        }
    }
}
