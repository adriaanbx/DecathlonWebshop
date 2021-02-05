using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IStringLocalizer<OrderController> _stringLocalizer;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, IStringLocalizer<OrderController> stringLocalizer)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _stringLocalizer = stringLocalizer;
        }
        public IActionResult CheckOut()
        {
            return View();
        }

        [Authorize(Policy ="MinimumOrderAge")]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some products first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = _stringLocalizer["TXT_Title"];
            return View();
        }
    }
}
