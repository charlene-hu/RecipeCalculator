using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator
{
    public class CalcWellnessDiscount : CalcHandler
    {
        private readonly decimal _discountRate;

        public CalcWellnessDiscount():this(0.05m)
        {
        }

        public CalcWellnessDiscount(decimal discountRate)
        {
            _discountRate = discountRate;
        }

        public override void Calculate(IList<ItemDto> items, IList<decimal> result)
        {
            if (items == null || result == null) return;
            decimal discount = 0;
            foreach (var item in items)
            {
               if(item.IsOrganic)
               {
                   discount += item.Price * (_discountRate);
               }
            }
            discount = -1 * Math.Ceiling(discount * 100) / 100;
            result.Add(discount);

            if (Successor != null)
            {
                Successor.Calculate(items, result);
            }
        }
    }
}