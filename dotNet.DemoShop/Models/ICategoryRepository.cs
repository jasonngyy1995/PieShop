using System;
using System.Collections.Generic;
namespace dotNet.DemoShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
