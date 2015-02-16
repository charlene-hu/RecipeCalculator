using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator
{
    public class CalcTotal : CalcHandler
    {
        public override void Calculate(IList<ItemDto> items, IList<decimal> result)
        {
            if (items == null || result == null) return;
            result.Add(Math.Ceiling(items.Sum(x => x.Price) * 100) / 100);
            if (Successor != null)
            {
                Successor.Calculate(items, result);
            }
        }
    }
}