# RecipeCalculator

RecipeCalculator is an ASP.NET MVC application. The landing page diplays three recipes. Upon hovering over a recipe name, ingredients, tax, discount and total price for the recipe is displayed. 

The data source is located in the App_Data folder and 
Entity Framework is used to query data from the source. Although this application was designed to be extended to support more features and data, there are only two projects in the solution due to the size of the application. RecipeCalculator contains all the code and the data source, and RecipeCalculator.Test contains the unit tests. 

Logging is implemented using log4net, jQuery and Bootstrap are used for the UI and NUnit is used for unit tests. There is certainly still room for improvmenet, eg, caching and better UI, etc. But due to time limit and the scope of the project, they are not included in this version of the application.
