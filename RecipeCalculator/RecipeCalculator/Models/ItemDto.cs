using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator.Models
{
    public class ItemDto
    {
        public bool IsOrganic { get; set; }
        public bool IsProduce { get; set; }
        public decimal Price { get; set; }
    }
}