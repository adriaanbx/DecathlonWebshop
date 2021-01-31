using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using DecathlonWebshop.Utilities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DecathlonWebshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
       // [Remote("CheckIfProductNameAlreadyExists","ProductManagement",ErrorMessage ="This product name already exists")]
        [Remote("CheckIfProductNameAlreadyExists", "ProductManagement")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public char Sex { get; set; }
        public decimal Price { get; set; }
        //TODO hoe custom made validate messages vertalen?
        //In ASP.NET Core MVC 1.1.0 and higher, non-validation attributes are localized. ASP.NET Core MVC 1.0 does not look up localized strings for non-validation attributes.
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
