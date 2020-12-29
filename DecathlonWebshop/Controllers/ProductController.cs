using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using DecathlonWebshop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        //public IActionResult List()
        //{
        //    ProductsListViewModel productViewModel = new ProductsListViewModel();

        //    productViewModel.Products = _productRepository.AllProducts;
        //    productViewModel.CurrentCategory = "Swimming";

        //    return View(productViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Product> product;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                product = _productRepository.AllProducts.OrderBy(p => p.Id);
                currentCategory = "All products";
            }
            else
            {
                product = _productRepository.AllProducts.Where(p => p.Category.Name == category)
                    .OrderBy(p => p.Id);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Name == category)?.Name;
            }

            return View(new ProductsListViewModel
            {
                Products = product,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
           var product =  _productRepository.GetProductById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }
    }
}
