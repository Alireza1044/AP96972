using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class RecipeTests
    {
        RecipeBook recipeBook = new RecipeBook("BookTitle", 1);
        Ingredient ingredient = new Ingredient("ingredientname", "ingredientdesciption", 2, "kg");
        List<Ingredient> ings2 = new List<Ingredient>();
        Recipe recipe = new Recipe("title", "instructions",
                    new List<Ingredient>(), 1, "iranian", new string[] { "test", "keyword" });
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
            Assert.IsTrue(recipe.RemoveIngredient("ingredientname"));
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
        public void SerializeTest()
        {
            Ingredient ing;
            ing = new Ingredient("name", "desc", 7.4, "kg");
            List<Ingredient> ings = new List<Ingredient>();
            ings.Add(ing);
            Recipe recipetest;
            recipetest = new Recipe("recipetitle", "use with waters", ings, 1, "iranian", new string[] { "iran", "food" });
            RecipeBook reBook;
            reBook = new RecipeBook("rebook", 1);
            string title;
            string instructions;
            int servingCount;
            string cuisine;
            int keywordsLen;
            string[] keywords;
            int ingredietLen;
            using (StreamWriter writer = new StreamWriter(@"recipestest.txt", false, Encoding.UTF8))
            {
                recipetest.Serialize(writer, @"ing3.txt");
            }
            using (StreamReader reader = new StreamReader(@"recipestest.txt"))
            {
                //aftdes = Recipe.Deserialize(reader, @"recipestest.txt");
                title = reader.ReadLine();
                instructions = reader.ReadLine();
                servingCount = int.Parse(reader.ReadLine());
                cuisine = reader.ReadLine();
                keywordsLen = int.Parse(reader.ReadLine());
                keywords = new string[keywordsLen];
                for (int i = 0; i < keywordsLen; i++)
                {
                    keywords[i] = reader.ReadLine();
                }
                ingredietLen = int.Parse(reader.ReadLine());
            }
            Assert.AreEqual(recipetest.Title, title);
            Assert.AreEqual(recipetest.Cuisine, cuisine);
            Assert.AreEqual(recipetest.Instructions, instructions);
            CollectionAssert.AreEqual(recipetest.Keywords, keywords);
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            Ingredient ing;
            ing = new Ingredient("name", "desc", 6.0, "kg");
            List<Ingredient> ings = new List<Ingredient>();
            ings.Add(ing);
            Recipe recipetest;
            Recipe recipetest2;
            recipetest = new Recipe("recipetitle", "use with water", ings, 1, "iranian", new string[] { "iran", "food" });
            recipetest.IngredientCount = 1;
            RecipeBook reBook;
            reBook = new RecipeBook("rebook", 1);
            reBook.Add(recipetest);
            using (StreamWriter writer = new StreamWriter(@"recipse.txt"))
            {
                recipetest.Serialize(writer, @"ing3.txt");
            }
            using (StreamReader reader = new StreamReader(@"recipse.txt"))
            {
                recipetest2 = Recipe.Deserialize(reader, @"recipse.txt", @"ing3.txt");
            }
            //Assert.AreEqual(recipetest.Cuisine, recipetest2.Cuisine);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            ings2.Add(ingredient);
            Recipe recipesstring = new Recipe("title", "instructions", ings2, 2, "cuisine", new string[] { "keyword", "key" });
            string info = "Title: " + recipesstring.Title + "\nInstructions: " + recipesstring.Instructions
                + "\nCuisine: " + recipesstring.Cuisine + "\nKeywords:\n";
            
            for (int i = 0; i < ings2.Count && ings2[i] != null; i++)
            {
                info += ings2[i].Name + "\n";
            }
            info += "Keywords:\n";
            for (int i = 0; i < recipesstring.Keywords.Length && recipesstring.Keywords[i] != null; i++)
            {
                info += recipesstring.Keywords[i] + "\n";
            }
            Assert.AreEqual(info,recipesstring.ToString());
        }
    }
}