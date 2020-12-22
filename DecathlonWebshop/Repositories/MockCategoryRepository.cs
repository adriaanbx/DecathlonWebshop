using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{Id = 1,Name = "Swimming", Description = "All swimming products"},
                new Category{Id = 2,Name = "Soccer", Description = "All Soccer products"},
                new Category{Id = 3,Name = "Fitness", Description = "All Fitness products"}
            };

    }
}
