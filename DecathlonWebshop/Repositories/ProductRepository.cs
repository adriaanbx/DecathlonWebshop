using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> AllProducts => _appDbContext.Products.Include(c=>c.Category);

        public IEnumerable<Product> ProductsOfTheWeek => _appDbContext.Products.Include(c=>c.Category).Where(p => p.IsProductOfTheWeek);

        public Product GetProductById(int id)
        {
           return _appDbContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
