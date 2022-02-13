using System;
using dotNet.DemoShop.ViewModels;
using dotNet.Models;
using Microsoft.AspNetCore.Mvc;

/* View components are similar to partial views, but they're much more powerful.
View components don't use model binding, and only depend on the data provided when calling into it */
namespace dotNet.DemoShop.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        // view components will search their views in a very specific location -> Views/Shared/Components
        public IViewComponentResult Invoke()
        {

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            return View(shoppingCartViewModel);
        }
    }
}
