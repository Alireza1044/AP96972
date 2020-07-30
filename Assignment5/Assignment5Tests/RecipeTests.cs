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
    public class RecipeTests
    {
        RecipeBook recipeBook = new RecipeBook("BookTitle", 1);
        Ingredient ingredient = new Ingredient("ingredientname", "ingredientdesciption", 2, "kg");
        Recipe recipe = new Recipe("title", "instructions",
                    new Ingredient[1], 1, "iranian", new string[] { "test", "keyword" });
        //Recipe recipe1 = new Recipe("title", "instructions",
        //            new Ingredient[] {"ingredientname", "ingredientdesciption", 2, "kg"} , 1, "iranian", new string[] { "test", "keyword" });
        [TestMethod()]
        public void AddIngredientTest()
        {
            Assert.IsTrue(recipe.AddIngredient(ingredient));
        }

        [TestMethod()]
        public void RemoveIngredientTest()
        {
            recipe.AddIngredient(ingredient);
            Assert.IsFalse(recipe.RemoveIngredient("test"));
        }

        [TestMethod()]
        public void UpdateServingCountTest()
        {
            int newservingcount = 4;
            recipe.AddIngredient(ingredient);
            recipe.UpdateServingCount(newservingcount);
            Assert.AreEqual(newservingcount, recipe.ServingCount);
        }

        [TestMethod()]
        public void RecipeTest()
        {
            Recipe recipe1 = new Recipe("recipe title", "test instructions", 3, 2, "iranian", new string[] { "test", "unit test" });
            Assert.AreEqual(recipe1.Title, "recipe title");
            Assert.AreEqual(recipe1.Instructions, "test instructions");
            Assert.AreEqual(recipe1.IngredientCount, 3);
            Assert.AreEqual(recipe1.ServingCount, 2);
            Assert.AreEqual(recipe1.Cuisine, "iranian");
            CollectionAssert.AreEqual(recipe1.Keywords, new string[] { "test", "unit test" });
        }

        [TestMethod()]
        public void RecipeTest1()
        {
            Ingredient[] ings = new Ingredient[2];
            ings[0] = new Ingredient("ing1", "ing desc", 2.4, "kg");
            ings[1] = new Ingredient("ing2", "ing2 description", 4.1, "gr");
            Recipe recipe = new Recipe("recipe title", "recipe instructs", ings, 3, "italian", new string[] { "iran", "food", "italy" });
            Assert.AreEqual(recipe.Instructions, "recipe instructs");
            CollectionAssert.AreEqual(recipe.Ingredients, ings);
            Assert.AreEqual(recipe.ServingCount, 3);
            Assert.AreEqual(recipe.Cuisine, "italian");
            CollectionAssert.AreEqual(recipe.Keywords, new string[] { "iran", "food","italy" });
        }
    }
}