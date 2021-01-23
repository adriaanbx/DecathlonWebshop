using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Auth
{
    public class DecathlonWebshopClaimTypes
    {
        public static List<string> ClaimsList { get; set; } = new List<string> { "Delete Product", "Add Product", "Age for ordering" };
    }
}
