using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeService _service;

        public HomeController(IRecipeService service)
        {
            _service = service;
        }
        
        public HomeController()
            : this(new RecipeService())
        { }

        public ActionResult Index()
        {
            var model = _service.GetRecipes();
            return View(model);
        }
    }
}
