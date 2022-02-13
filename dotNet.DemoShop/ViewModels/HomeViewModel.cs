using System;
using System.Collections.Generic;
using dotNet.DemoShop.Models;

namespace dotNet.DemoShop.ViewModels
{
    public class HomeViewModel
    {        
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }

}
