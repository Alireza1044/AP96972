using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class IngredientTests
    {
        [TestMethod()]
        public void IngredientTest()
        {
            Ingredient ingredient = new Ingredient("ingredient name", "ingredient description", 2.8, "gr");
            Assert.AreEqual(ingredient.Name,"ingredient name");
            Assert.AreEqual(ingredient.Description, "ingredient description");
            Assert.AreEqual(ingredient.Unit, "gr");
            Assert.AreEqual(ingredient.Quantity, 2.8);
        }
    }
}