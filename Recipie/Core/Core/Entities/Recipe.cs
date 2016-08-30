using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Core.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Totals { get; set; }
    }
    
}
