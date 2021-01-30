using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using DecathlonWebshop.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public char Sex { get; set; }
        public decimal Price { get; set; }
        [ValidUrl(ErrorMessage ="Please fill in a correct URL")]
        public string ImageUrl { get; set; }
        [ValidUrl(ErrorMessage = "Please fill in a correct URL")]
        public string ImageThumbnailUrl { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public List<ProductReview> Reviews { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
