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

        public async Task<IEnumerable<Product>> GetProductsAsync() => await _appDbContext.Products.Include(c => c.Category).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsOfTheWeekAsync() => await _appDbContext.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek).ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _appDbContext.Products.Include(p => p.Reviews).Include(c=>c.Category).FirstOrDefaultAsync(p => p.Id == id);

        public async Task CreateProductAsync(Product product)
        {
           _appDbContext.Products.Add(product);
           await _appDbContext.SaveChangesAsync();

            //TODO
            // Detach the product,to be able to update it afterwards, to avoid
            // The instance of entity type cannot be tracked because another instance with the same key value for {'...'} is already being tracked
            //_appDbContext.Entry(product).State = EntityState.Detached;
        }

        public async Task UpdateProductAsync(Product product)
        {
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteProductAsync(Product product)
        {
            _appDbContext.Products.Remove(product);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
           return  await _appDbContext.Products.FirstOrDefaultAsync(p => p.Name == productName);
        }
    }
}
