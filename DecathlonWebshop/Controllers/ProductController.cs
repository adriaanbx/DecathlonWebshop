using DecathlonWebshop.Contracts;
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
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ProductsListViewModel productViewModel = new ProductsListViewModel();

            productViewModel.Products = _productRepository.AllProducts;
            productViewModel.CurrentCategory = "Swimming";

            return View(productViewModel);
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
