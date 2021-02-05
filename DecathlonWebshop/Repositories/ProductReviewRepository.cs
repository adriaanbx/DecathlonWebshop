using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public AppDbContext Db { get; }

        public async Task AddProductReviewAsync(ProductReview productReview)
        {
            _appDbContext.ProductReviews.Add(productReview);
            await _appDbContext.SaveChangesAsync();
          
        }


        public async Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId) => await _appDbContext.ProductReviews.Where(p => p.Id == productId).ToListAsync();

    }
}
