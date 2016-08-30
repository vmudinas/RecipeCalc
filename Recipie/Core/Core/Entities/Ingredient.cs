using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Ingredient
    {
        [Key]
        private int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Organic { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
