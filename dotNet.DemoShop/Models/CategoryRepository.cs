using System;
using System.Collections.Generic;

namespace dotNet.DemoShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        // return all Categories
        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }

}