using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator
{
    public abstract class CalcHandler
    {
        protected CalcHandler Successor { get; set; }
        public void SetSuccessor(CalcHandler next)
        {
            Successor = next;
        }
        public abstract void Calculate(IList<ItemDto> items, IList<decimal> result);
    }
}