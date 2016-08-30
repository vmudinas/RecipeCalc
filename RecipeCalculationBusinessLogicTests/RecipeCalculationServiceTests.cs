using System.Linq;
using Core.Service;
using DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeTests
{
    [TestClass()]
    public class RecipeCalculationServiceTests
    {
        [TestMethod()]
        public void RecipeTotalsTest()
        {
            var repo = new RecipieRepo();
            var getRecepies = new DataService(repo);
            var actualTotals = getRecepies.GetAllRecipies();


            var calculation = new CalculationService();
            calculation.ProcessRecipie(actualTotals);

        
            //First Recipe 
            Assert.AreEqual(0.21m, actualTotals.Recipies.Where(x=>x.Id == 1).Select(x => x.TotalTax).FirstOrDefault());
            Assert.AreEqual(0.11m, actualTotals.Recipies.Where(x => x.Id == 1).Select(x => x.TotalDiscount).FirstOrDefault());
            Assert.AreEqual(4.45m, actualTotals.Recipies.Where(x => x.Id == 1).Select(x => x.Totals).FirstOrDefault());

            //Second Recipe 
            Assert.AreEqual(0.91m, actualTotals.Recipies.Where(x => x.Id == 2).Select(x => x.TotalTax).FirstOrDefault());
            Assert.AreEqual(0.09m, actualTotals.Recipies.Where(x => x.Id == 2).Select(x => x.TotalDiscount).FirstOrDefault());
            Assert.AreEqual(11.84m, actualTotals.Recipies.Where(x => x.Id == 2).Select(x => x.Totals).FirstOrDefault());

            //Third Recipe 
            Assert.AreEqual(0.42m, actualTotals.Recipies.Where(x => x.Id == 3).Select(x => x.TotalTax).FirstOrDefault());
            Assert.AreEqual(0.07m, actualTotals.Recipies.Where(x => x.Id == 3).Select(x => x.TotalDiscount).FirstOrDefault());
            Assert.AreEqual(8.91m, actualTotals.Recipies.Where(x => x.Id == 3).Select(x => x.Totals).FirstOrDefault());

        }
        



        [TestMethod()]
        public void ApplyDiscountTest()
        {
            const decimal value = 100;
            const decimal discountPercentigeApplied = 0.95m;
            const decimal discountExpected = 95;


            var taxCalculation = new CalculationService();
            var actualDiscount = taxCalculation.ApplyDiscount(value, discountPercentigeApplied);

            Assert.AreEqual(discountExpected, actualDiscount);
        }

        [TestMethod()]
        public void ApplyDiscountRoundingTest()
        {
            const decimal value = 100.74158m;
            const decimal discountPercentigeApplied = 0.95m;
            const decimal discountExpected = 95.71m;
            
            var taxCalculation = new CalculationService();
            //price rounded up to the nearest cent
            var actualDiscount = taxCalculation.NearestOfPenny(taxCalculation.ApplyDiscount(value, discountPercentigeApplied));

            Assert.AreEqual(discountExpected, actualDiscount);
        }
        [TestMethod()]
        public void ApplyTaxTest()
        {
            const decimal value = 15.15m;
            const decimal taxApplied = 0.086m;
            const decimal taxExpected = 1.3029m;


            var taxCalculation = new CalculationService();

            var actualTax = taxCalculation.ApplyTaxPercentige(value, taxApplied);

            Assert.AreEqual(taxExpected, actualTax);
        }
        [TestMethod()]
        public void ApplyTaxRoundingTest()
        {
            const decimal value = 15.15m;
            const decimal taxApplied = 0.086m;
            const decimal taxExpected = 1.33m;


            var taxCalculation = new CalculationService();
            //price rounded up to the nearest 7 cents
            var actualTax = taxCalculation.NearestOf7Cents(taxCalculation.ApplyTaxPercentige(value, taxApplied));
            Assert.AreEqual(taxExpected, actualTax);

        }
    }
}



