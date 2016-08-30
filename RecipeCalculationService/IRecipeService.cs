using System.Collections.Generic;
using RecipeModel;

namespace RecipeCalculationService
{
    /// <summary>
    /// Dependency interface
    /// </summary>
    public interface IRecipeService
    {
        List<RecipeCalculationResult> ReturnRecipeTotals(RecipeTotals recipeTotals);
        double ReturnRounding(double value, double nearestValue);
        double ApplyDiscount(double value, double discount);
        double ApplyTaxPercentige(double value, double tax);

    }
}