using System;
using System.Collections.Generic;
using System.Linq;
using RecipeModel;

namespace RecipeCalculationService
{
    /// <summary>
    /// Concrete type for depency
    /// </summary>
    public class RecipeCalculationService : IRecipeService
    {
        public List<RecipeCalculationResult> ReturnRecipeTotals(RecipeTotals recipeTotals)
        {
           

            var recipeList = new List<RecipeCalculationResult>();

            foreach (var value in recipeTotals.Recipes)
            {

                var discount = ReturnRounding(ApplyDiscount(value.Ingredients.Where(x => x.Organic).Sum(x => x.Amount*x.Price),recipeTotals.WellnessDiscountPercentige),0.07);

                var tax = ReturnRounding(ApplyTaxPercentige(value.Ingredients.Where(x => x.Type != "Produce").Sum(x => x.Amount * x.Price), recipeTotals.TaxPercentige),0.07);

                var totalPrice = value.Ingredients.Sum(x => x.Amount*x.Price) + tax - discount;

                recipeList.Add(
                    new RecipeCalculationResult
                {
                    TotalDiscount = discount,
                    TotalTax = tax,
                    Totals = totalPrice
                    });
            }
            


            return recipeList;
        }

        public double ReturnRounding(double value, double nearestValue)
        {
            return Math.Round(value * nearestValue) / nearestValue;
        }

        public double ApplyDiscount(double value, double discount)
        {
            return value * (1 - discount);
        }

        public double ApplyTaxPercentige(double value, double tax)
        {
            return value * tax;
        }

      
    }
}