using DecathlonWebshop.Contracts;
using DecathlonWebshop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public AjaxController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Addproduct()
        {
            var categories = _categoryRepository.AllCategories;
            var productEditViewModel = new ProductEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().Id
            };
            return View(productEditViewModel);
        }
}
}
