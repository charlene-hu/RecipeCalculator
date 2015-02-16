using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeCalculator.Models
{
    public class RecipeViewModel
    {
        public string RecipeName { get; set; }
        public IList<string> Ingredients { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public RecipeViewModel()
        {
            Ingredients = new List<string>();
        }
    }
}