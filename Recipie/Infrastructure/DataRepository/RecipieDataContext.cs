using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using System.Data.Entity;

namespace DataRepository
{
    public class RecipieRepoDataContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipies { get; set; }

        public DbSet<RecipeTotals> RecipeTotals { get; set; }


    }
}
