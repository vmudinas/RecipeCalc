using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Core.Entities
{
    public class RecipeTotals
    {
        [Key]
        public int Id { get; set; }

       
        public List<Recipe> Recipies { get; set; }

        public decimal TaxPercentage { get; set; }
        public decimal WellnessDiscountPercentage { get; set; }
    }
    
}
