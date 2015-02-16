using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{
    public interface IRecipeService
    {
        IList<RecipeViewModel> GetRecipes();
    }
}
