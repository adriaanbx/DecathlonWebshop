﻿using DecathlonWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Contracts
{
    public interface IProductReviewRepository
    {
        Task AddProductReviewAsync(ProductReview productReview);
        Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId);
    }
}
