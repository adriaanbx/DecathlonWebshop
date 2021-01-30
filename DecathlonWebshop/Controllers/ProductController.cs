using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using DecathlonWebshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DecathlonWebshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IProductReviewRepository productReviewRepository, HtmlEncoder htmlEncoder)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productReviewRepository = productReviewRepository;
            _htmlEncoder = htmlEncoder;
        }


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
            var product = _productRepository.GetProductById(id);
            if (product is null)
                return NotFound();

            return View(new ProductDetailViewModel { Product = product });
        }

        [HttpPost]
        //TODO hoe komt het dat dit werkt? je verwacht als return type een Task<IActionResult> en je geeft een ViewResult terug zonder task?
        public async Task<IActionResult> Details(int id, string review)
        {
            var product = _productRepository.GetProductById(id);
            if (product is null)
                return NotFound();

            //Sanitazing input to prevent XSS = Cross Site Scripting
            string encodedReview = _htmlEncoder.Encode(review);

            await _productReviewRepository.AddProductReviewAsync(new ProductReview
            {
                Product = product,
                Review = encodedReview
            });

            ModelState.Clear();
            //TODO Hoe komt het dat dit werkt? je roept de Details view terug op maar je geeft het "oude product, zonder de aanpassing in de reviews mee"
            //en toch wordt deze al getoond? Dit object wordt dus mee geupdated?
            return View(new ProductDetailViewModel { Product = product });
        }
    }
}
