using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace DataRepository
{
    public class RecipieRepo : IDataRepository
    {
        public RecipeTotals GetAllRecipies()
        {
            var recipeIngredients = new List<Ingredient>()
            {
                new Ingredient {Amount = 1,Name="Garlic Clove",Organic = true,Price= 0.67m,Type="Produce"},
                new Ingredient { Amount = 1, Name = "Lemon", Organic = false, Price = 2.03m, Type = "Produce" },
                new Ingredient { Amount = 0.75m, Name = "Olive Oil", Organic = true, Price = 1.92m, Type = "Pantry" },
                new Ingredient { Amount = 0.75m, Name = "Salt", Organic = false, Price = 0.16m, Type = "Pantry" },
                new Ingredient { Amount = 0.50m, Name = "Pepper", Organic = false, Price = 0.17m, Type = "Pantry" }
            };
            var recipeIngredients2 = new List<Ingredient>()
            {
                new Ingredient {Amount = 1,Name="Garlic Clove",Organic = true,Price= 0.67m,Type="Produce"},
                new Ingredient { Amount = 4, Name = "Chicken Breasts", Organic = false, Price = 2.19m, Type = "Meat/poultry" },
                new Ingredient { Amount = 0.5m, Name = "Olive Oil", Organic = true, Price = 1.92m, Type = "Pantry" },
                new Ingredient { Amount = 0.5m, Name = "Vinegar", Organic = false, Price = 1.26m, Type = "Pantry" }
            };
            var recipeIngredients3 = new List<Ingredient>()
            {
                new Ingredient {Amount = 1, Name = "Garlic Clove", Organic = true, Price = 0.67m, Type = "Produce"},
                new Ingredient {Amount = 4, Name = "Corn", Organic = false, Price = .87m, Type = "Produce"},
                new Ingredient {Amount = 4m, Name = "Bacon", Organic = false, Price = .24m, Type = "Meat/poultry"},
                new Ingredient {Amount = 8, Name = "Pasta", Organic = false, Price = 0.31m, Type = "Pantry"},
                new Ingredient {Amount = (1.0m/3.0m), Name = "Olive Oil", Organic = true, Price = 1.92m, Type = "Pantry"},
                new Ingredient {Amount = 1.25m, Name = "Salt", Organic = false, Price = 0.16m, Type = "Pantry"},
                new Ingredient {Amount = (3.0m/4.0m), Name = "Pepper", Organic = false, Price = 0.17m, Type = "Pantry"}
            };


            var recipeList = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Ingredients = recipeIngredients,
                    Name = "Recipe 1"
                },
                  new Recipe()
                {
                    Id = 2,
                    Ingredients = recipeIngredients2,
                    Name = "Recipe 2"
                },
                    new Recipe()
                {
                    Id = 3,
                    Ingredients = recipeIngredients3,
                    Name = "Recipe 3"
                }
            };

            var recipeTotal = new RecipeTotals
            {
                Id =1,
                WellnessDiscountPercentage = .05m,
                TaxPercentage = .086m,
                Recipies = recipeList
            };
            return recipeTotal;
        }

       
    }
}
