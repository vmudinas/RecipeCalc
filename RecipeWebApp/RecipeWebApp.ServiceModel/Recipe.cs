using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Entities;
using ServiceStack;

namespace RecipeWebApp.ServiceModel
{
    [Route("/GetAllRecipies")]
    public class Recipe : IReturn<RecipeResponse>
    {
       
    }

    public class RecipeResponse
    {
        public RecipeTotals Result { get; set; }
    }

    //[Route("/hello/{Name}")]
    //public class Hello : IReturn<HelloResponse>
    //{
    //    public RecipeTotals Name { get; set; }
    //}

    //public class HelloResponse
    //{
    //    public string Result { get; set; }
    //}

    [Route("/GetTotal")]
    public class RecipeCalculation: IReturn<RecipeTotalsResponse>
    {
        public int Id { get; set; }
        public List<Core.Entities.Recipe> Recipies { get; set; }

        public decimal TaxPercentage { get; set; }
        public decimal WellnessDiscountPercentage { get; set; }
    }
    public class RecipeTotalsResponse
    {
        public RecipeTotals Result { get; set; }
    }
}