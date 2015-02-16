using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator
{
    public class CalcTax : CalcHandler
    {
        private readonly decimal _taxRate;

        public CalcTax(): this(0.086m)
        {
        }

        public CalcTax(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public override void Calculate(IList<ItemDto> items,
            IList<decimal> result)
        {
            if (items == null || result == null) return;
            decimal tax = 0;
            foreach (var item in items)
            {
                if (!item.IsProduce)
                {
                    tax += item.Price * (_taxRate);
                }
            }
            tax = Helper.RoundToSevenCent(Math.Ceiling(tax * 100) / 100);
            result.Add(tax);

            if (Successor != null)
            {
                Successor.Calculate(items, result);
            }
        }
    }
}