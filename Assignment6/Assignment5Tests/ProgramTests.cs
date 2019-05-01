using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetBookInputTest()
        {
            using (StreamWriter writer = new StreamWriter(@"reader.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("book name");
                Console.WriteLine(21);
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader.txt"))
            {
                Console.SetIn(reader);
                RecipeBook reBook = Program.GetBookInput();
                Assert.AreEqual(reBook.Title, "book name");
                Assert.AreEqual(reBook.Capacity, 21);
            }
        }

        [TestMethod()]
        public void GetRecipeInputTest()
        {
            using (StreamWriter writer = new StreamWriter(@"reader2.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("instructions");
                Console.WriteLine("12");
                Console.WriteLine("cuisine");
                Console.WriteLine("keywords iranian italian");
                Console.WriteLine("2");
                Console.WriteLine("title");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader2.txt"))
            {
                Console.SetIn(reader);
                Recipe recipeTest = Program.GetRecipeInput();
                Assert.AreEqual(recipeTest.Title, "title");
                Assert.AreEqual(recipeTest.ServingCount, 12);
                Assert.AreEqual(recipeTest.Instructions, "instructions");
                Assert.AreEqual(recipeTest.Cuisine, "cuisine");
                CollectionAssert.AreEqual(recipeTest.Keywords, new string[] { "keywords", "iranian", "italian" });
                //string instructs = Console.ReadLine();
                //int servingCount = int.Parse(Console.ReadLine());
                //string cuisine = Console.ReadLine();
                //string[] keywords = Console.ReadLine().Split();
                //int ingredientCount = int.Parse(Console.ReadLine());
                //string title = Console.ReadLine();
            }
        }

        [TestMethod()]
        public void GetIngredientInputTest()
        {
            using (StreamWriter writer = new StreamWriter(@"reader3.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("desc");
                Console.WriteLine("kg");
                Console.WriteLine("ing name");
                Console.WriteLine("2");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader3.txt"))
            {
                Console.SetIn(reader);
                Ingredient ing = Program.GetIngredientInput();
                Assert.AreEqual(ing.Name, "ing name");
                Assert.AreEqual(ing.Quantity, 2);
                Assert.AreEqual(ing.Unit, "kg");
                Assert.AreEqual(ing.Description, "desc");
            }
        }

        [TestMethod()]
        public void RemoveByTitleTest()
        {
            RecipeBook recipeBook = new RecipeBook("reBook", 2);
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            List<Ingredient> ings2 = new List<Ingredient>();
            ings2.Add(ing);
            Recipe recipe = new Recipe("title", "instructions", ings2, 3, "cuisine", new string[] { "keywords", "iranian" });
            recipeBook.Add(recipe);
            using (StreamWriter writer = new StreamWriter(@"reader4.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("title");
                Console.SetOut(a);
            }

            using (StreamReader reader = new StreamReader(@"reader4.txt"))
            {
                Console.SetIn(reader);
                Recipe recipeTitle = Program.RemoveByTitle(recipeBook);
                Assert.AreEqual(recipeTitle.Title, "title");
            }
        }

        [TestMethod()]
        public void RemoveByKeywordTest()
        {
            RecipeBook recipeBook = new RecipeBook("reBook", 2);
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            Ingredient ing1 = new Ingredient("name1", "desc1", 21.5, "kg");
            List<Ingredient> ings2 = new List<Ingredient>();
            ings2.Add(ing);
            ings2.Add(ing1);
            Recipe recipe = new Recipe("title", "instructions", ings2, 3, "cuisine", new string[] { "title", "iranian" });
            recipeBook.Add(recipe);
            recipeBook.Add(recipe);
            using (StreamWriter writer = new StreamWriter(@"reader5.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("title");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader5.txt"))
            {
                Console.SetIn(reader);
                Recipe[] recipeKeyword = Program.RemoveByKeyword(recipeBook);
                for (int i = 0; i < recipeKeyword.Length && recipeKeyword[i] != null; i++)
                {
                    Assert.AreEqual(recipeKeyword[i].Title, "title");
                }
            }
        }

        [TestMethod()]
        public void UpdateServingCountTest()
        {
            using (StreamWriter writer = new StreamWriter(@"reader6.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("3");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader6.txt"))
            {
                Console.SetIn(reader);
                Assert.AreEqual(Program.UpdateServingCount(), 3);
            }
        }

        [TestMethod()]
        public void RemoveByCuisineTest()
        {
            RecipeBook recipeBook = new RecipeBook("reBook", 2);
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            List<Ingredient> ings2 = new List<Ingredient>();
            ings2.Add(ing);
            Recipe recipe = new Recipe("title", "instructions", ings2, 3, "cuisine", new string[] { "keywords", "iranian" });
            recipeBook.Add(recipe);
            using (StreamWriter writer = new StreamWriter(@"reader7.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("cuisine");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader7.txt"))
            {
                Console.SetIn(reader);
                Recipe[] recipeCuisine = Program.RemoveByCuisine(recipeBook);
                for (int i = 0; i < recipeCuisine.Length && recipeCuisine[i] != null; i++)
                {
                    Assert.AreEqual(recipeCuisine[i].Title, recipe.Title);
                }
            }
        }

        [TestMethod()]
        public void RemoveIngredientTest()
        {
            RecipeBook recipeBook = new RecipeBook("reBook", 2);
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            List<Ingredient> ings2 = new List<Ingredient>();
            ings2.Add(ing);
            Recipe recipe = new Recipe("title", "instructions", ings2, 3, "cuisine", new string[] { "keywords", "iranian" });
            recipeBook.Add(recipe);
            using (StreamWriter writer = new StreamWriter(@"reader8.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("ing");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader8.txt"))
            {
                Console.SetIn(reader);
                string nameToDelete = Program.RemoveIngredient();
                Assert.AreEqual(nameToDelete, "ing");
            }
        }

        [TestMethod()]
        public void DeleteRecipeTest()
        {
            RecipeBook recipeBook = new RecipeBook("reBook", 2);
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            List<Ingredient> ings2 = new List<Ingredient>();
            ings2.Add(ing);
            Recipe recipe = new Recipe("title", "instructions", ings2, 3, "cuisine", new string[] { "keywords", "iranian" });
            recipeBook.Add(recipe);
            using (StreamWriter writer = new StreamWriter(@"reader9.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("recipe");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader9.txt"))
            {
                Console.SetIn(reader);
                string nameToDelete = Program.DeleteRecipe(ref recipeBook);
                Assert.AreEqual(nameToDelete, "recipe");
            }
        }

        [TestMethod()]
        public void ReadActionTest()
        {
            using (StreamWriter writer = new StreamWriter(@"reader10.txt"))
            {
                var a = Console.Out;
                Console.SetOut(writer);
                Console.WriteLine("title");
                Console.SetOut(a);
            }
            using (StreamReader reader = new StreamReader(@"reader10.txt"))
            {
                Console.SetIn(reader);
                Assert.AreEqual(Program.ReadAction(), "title");
            }
        }

        [TestMethod()]
        public void LoadRecipesTest()
        {
            RecipeBook recipeBook = new RecipeBook("reBook", 1);
            RecipeBook recipeBook1 = new RecipeBook("reBook1", 1);
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            List<Ingredient> ings2 = new List<Ingredient>();
            ings2.Add(ing);
            Recipe recipe = new Recipe("title", "instructions", ings2, 3, "cuisine", new string[] { "keywords", "iranian" });
            recipeBook.Add(recipe);
            Assert.IsFalse(Program.LoadRecipes(ref recipeBook1,@"asdasd.txt",@"dsadsa.txt"));
            recipeBook.Save(@"recipe.txt", @"ingredient.txt");
            Assert.IsTrue(Program.LoadRecipes(ref recipeBook1,@"recipe.txt",@"ingredient.txt"));
        }
    }
}