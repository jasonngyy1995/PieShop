using System.Collections.Generic;
using dotNet.DemoShop.Models;

namespace dotNet.DemoShop.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
