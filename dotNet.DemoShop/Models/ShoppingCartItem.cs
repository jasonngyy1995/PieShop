using System;
namespace dotNet.DemoShop.Models
{
    public class ShoppingCartItem
    {
        public string ShoppingCartId { get; set; }
        public Pie Pie { get; set; }
        public int Amount { get; set; }
        public int ShoppingCartItemId { get; set; }
    }
}
