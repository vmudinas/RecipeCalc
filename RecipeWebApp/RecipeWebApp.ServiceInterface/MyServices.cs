using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Entities;
using Core.Service;
using DataRepository;
using RecipeWebApp.ServiceModel;
using ServiceStack;
using Recipe = RecipeWebApp.ServiceModel.Recipe;

namespace RecipeWebApp.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Recipe request)
        {
            var repo = new RecipieRepo();
            var getRecepies = new DataService(repo);
            return getRecepies.GetAllRecipies();
        }
      
        public object Any(RecipeCalculation request)
        {
            var calculation = new CalculationService();
            return calculation.ProcessRecipie(new RecipeTotals { Id = request.Id, Recipies = request.Recipies, TaxPercentage = request.TaxPercentage, WellnessDiscountPercentage = request.WellnessDiscountPercentage });
        }

        public object Any(FallbackForClientRoutes request)
        {
            //Return default.cshtml for unmatched requests so routing is handled on the client
            return new HttpResult
            {
                View = "/default.cshtml"
            };
        }
    }

        [FallbackRoute("/{PathInfo*}")]
        public class FallbackForClientRoutes
        {
            public string PathInfo { get; set; }
        }
}