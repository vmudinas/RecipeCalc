using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace Core.Service
{
    public class CalculationService: ICalculation
    {
        

        public void OrganicDiscount(Recipe recipe, decimal discount)
        {

            recipe.TotalDiscount =
                NearestOfPenny(ApplyDiscount(recipe.Ingredients.Where(x => x.Organic).Sum(x => x.Amount*x.Price),
                    discount));

        }

        public void TaxCalculation(Recipe recipe, decimal tax)
        {
            recipe.TotalTax =
               NearestOf7Cents(ApplyTaxPercentige(recipe.Ingredients.Where(x => x.Type != "Produce").Sum(x => x.Amount * x.Price),
                   tax));

        }
        public decimal NearestOf7Cents(decimal amountToRound)
        {
            return RoundingFunction(amountToRound, 0.07m, 0.4999999999999999m);
        }
        public decimal NearestOfPenny(decimal amountToRound)
        {
            return RoundingFunction(amountToRound, 0.01m, 0.4999999999999999m);
        }

        public decimal RoundingFunction(decimal amountToRound, decimal nearstOf, decimal fairness)
        {
            return Math.Round(amountToRound / nearstOf + fairness) * nearstOf;
        }

        public decimal ApplyDiscount(decimal value, decimal discount)
        {
            return value * discount;
        }

        public decimal ApplyTaxPercentige(decimal value, decimal tax)
        {
            return value * tax;
        }

        public RecipeTotals ProcessRecipie(RecipeTotals recipies)
        {
            if (recipies.Recipies == null) return recipies;
            foreach (var recipe in recipies.Recipies)
            {
                OrganicDiscount(recipe, recipies.WellnessDiscountPercentage);
                TaxCalculation(recipe, recipies.TaxPercentage);
                recipe.Totals = Math.Round(recipe.Ingredients.Sum(x => x.Amount*x.Price) + recipe.TotalTax - recipe.TotalDiscount,2, MidpointRounding.AwayFromZero);

            }


            return recipies;
        }
    }
}
