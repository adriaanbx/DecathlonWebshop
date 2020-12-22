using DecathlonWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> ProductsOfTheWeek { get; }
        Product GetProductById(int Id);

    }
}
