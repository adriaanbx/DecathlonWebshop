using DecathlonWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsOfTheWeekAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByNameAsync(string productName);
        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

    }
}
