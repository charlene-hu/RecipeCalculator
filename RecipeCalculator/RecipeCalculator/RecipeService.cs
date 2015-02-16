using log4net;
using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{
    public class RecipeService:IRecipeService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RecipeService));
        private readonly RecipeContext _context;
        private int _produceId;

        public RecipeService()
        {
            _context = new RecipeContext();
        }

        public IList<RecipeViewModel> GetRecipes()
        {
            _produceId = _context.Categories.
                Where(x => x.Active &&
                    x.Name.Equals("Produce", StringComparison.OrdinalIgnoreCase)).First().Id;

            var list = new List<RecipeViewModel>();
            
            var recipes = _context.Recipes.Where(x => x.Active).ToList();
            foreach (var recipe in recipes)
            {
                var items = recipe.RecipeItems.Where(x => x.Active);
                //if no ingredients for this recipe, skip
                if (items.Count() == 0)
                {
                    logger.ErrorFormat("recipe: {0} contains no ingredients", recipe.Name);
                    continue;
                }

                var model = new RecipeViewModel();
                model.RecipeName = recipe.Name;

                foreach (var item in items)
                {
                    if (item.Unit.Name.Equals("count", StringComparison.OrdinalIgnoreCase))
                    {
                        model.Ingredients.Add(item.Quantity + " " + item.Item.Name);
                    }
                    else
                    {
                        model.Ingredients.Add(item.Quantity + " " +
                             item.Unit.Name + " " + item.Item.Name);
                    }
                }
                var result = CalculateRecipe(items);
                if (result.Count != 3)
                {
                    logger.ErrorFormat("recipe calculation error for recipe: {0}", recipe.Name);
                    continue;
                }
                model.Discount = result[1];
                model.Tax = result[2];
                model.Total = Math.Ceiling((result[0] + result[1] + result[2])*100)/100;
                list.Add(model);
            }
            return list;
        }

        private IList<decimal> CalculateRecipe(IEnumerable<RecipeItem> items)
        {
            IList<ItemDto> itemList = new List<ItemDto>();
            foreach(var item in items)
            {
                var price = _context.Prices.Where(x => x.Active && 
                    x.UnitId == item.UnitId && x.ItemId == item.ItemId)
                    .First().Price1 * (decimal)item.Quantity;
                itemList.Add(
                    new ItemDto()
                    {
                        IsOrganic = item.Item.Organic,
                        IsProduce = item.Item.CategoryId == _produceId,
                        Price = price
                    });
            }
            var totalCalc = new CalcTotal();
            var taxCalc = new CalcTax();
            var discountCalc = new CalcWellnessDiscount();
            IList<decimal> result = new List<decimal>();
            totalCalc.SetSuccessor(discountCalc);
            discountCalc.SetSuccessor(taxCalc);
            totalCalc.Calculate(itemList, result);
            return result;
        }
    }
}
