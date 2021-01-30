using DecathlonWebshop.Contracts;
using DecathlonWebshop.Models;
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

        //public void AddProductReview(ProductReview productReview)
        //{
        //    _appDbContext.ProductReviews.Add(productReview);
        //    _appDbContext.SaveChangesAsync();

        //}

        public async Task<Task> AddProductReviewAsync(ProductReview productReview)
        {
            _appDbContext.ProductReviews.Add(productReview);
            await _appDbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }

        //TODO hoe query async uitvoeren op database niveau? want nu lijkt de "Where" op applicatie niveau?
        //Of hoe kan je weer zien of LINQ op database niveau werkt of op applicatieniveau?

        //public async Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId)
        //{
        //    var result = await _appDbContext.ProductReviews.Where(p => p.Id == productId);
        //    return Task.FromResult(result);
        //}

        public IEnumerable<ProductReview> GetProductReviews(int productId)
        {
            return _appDbContext.ProductReviews.Where(p => p.Id == productId);
        }
    }
}
