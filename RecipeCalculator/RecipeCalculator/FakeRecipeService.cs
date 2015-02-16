using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCalculator
{
    public class FakeRecipeService: IRecipeService
    {
        public IList<RecipeViewModel> GetRecipes()
        {
            var recipes = new List<RecipeViewModel>();
            recipes.Add(new RecipeViewModel
            {
                RecipeName = "Test Recipe One",
                Ingredients = new List<string>
                {
                    "1 ounce olive oil",
                    "1 teaspoon pepper",
                    "1 clove garlic",
                    "1/4 teaspoon of salt",
                    "2 chicken breasts"
                },
                Tax = 1.17m,
                Discount = -0.25m,
                Total = 9.97m
            });
            recipes.Add(new RecipeViewModel
            {
                RecipeName = "Test Recipe Two",
                Ingredients = new List<string>
                {
                    "1 cup vinegar",
                    "8 oucne pasta",
                    "2 clove garlic",
                    "1/4 teaspoon of salt",
                    "2 slices bacon"
                },
                Tax = 0.77m,
                Discount = -0.5m,
                Total = 12.97m
            });
            recipes.Add(new RecipeViewModel
            {
                RecipeName = "Test Recipe Three",
                Ingredients = new List<string>
                {
                    "2 teaspoon olive oil",
                    "2 teaspoon pepper",
                    "1 clove garlic",
                    "1/2 teaspoon of salt",
                    "2 chicken breasts"
                },
                Tax = 1.49m,
                Discount = -0.65m,
                Total = 7.97m
            });
            return recipes;
        }
    }
}