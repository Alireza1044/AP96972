using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class RecipeBookTests
    {
        RecipeBook recipeBook = new RecipeBook("recipeBookName", 2);
        Recipe recipe = new Recipe("title", "instructions",
            new Ingredient[1], 1, "iranian", new string[] { "test", "keyword" });
        Recipe recipe1 = new Recipe("title1", "instructions",
           new Ingredient[1], 1, "iranian", new string[] { "test", "keyword" });
        Ingredient ing = new Ingredient("ingname", "ingdesc", 5.8, "kg");
        [TestMethod()]
        public void AddTest()
        {
            Assert.IsTrue(recipeBook.Add(recipe));
            recipeBook.Add(recipe);
            Assert.IsFalse(recipeBook.Add(recipe));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            recipeBook.Add(recipe);
            Assert.IsTrue(recipeBook.Remove("title"));
            recipeBook.Add(recipe);
            Assert.IsFalse(recipeBook.Remove("test"));
        }

        [TestMethod()]
        public void LookupByTitleTest()
        {
            recipeBook.Add(recipe);
            Assert.AreEqual(recipeBook.LookupByTitle("title"), recipe);
        }

        [TestMethod()]
        public void LookupByKeywordTest()
        {
            recipeBook.Add(recipe);
            CollectionAssert.Contains(recipeBook.LookupByKeyword("keyword"), recipe);
        }

        [TestMethod()]
        public void LookupByCuisineTest()
        {
            recipeBook.Add(recipe);
            CollectionAssert.Contains(recipeBook.LookupByCuisine("iranian"), recipe);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            recipeBook.Add(recipe);
            recipeBook.Add(recipe1);
            CollectionAssert.AreEqual(recipeBook.ToString(), new string[] { "title", "title1" });
            CollectionAssert.AreNotEqual(recipeBook.ToString(), new string[] { "title1", "title" });
        }

        [TestMethod()]
        public void RecipeBookTest()
        {
            RecipeBook recipeBook1 = new RecipeBook("the title", 1);
            Assert.AreEqual(recipeBook1.Title, "the title");
            Assert.AreEqual(recipeBook1.Capacity, 1);
        }

        [TestMethod()]
        public void SaveTest()
        {
            recipeBook.Add(recipe);
            recipeBook.Save(@"recipe.txt",@"ing4.txt");
            Assert.IsTrue(File.Exists(@"recipe.txt"));
        }

        [TestMethod()]
        public void LoadTest()
        {
            recipeBook.Add(recipe);
            recipeBook.Add(recipe1);
            recipe.AddIngredient(ing);
            recipe1.AddIngredient(ing);
            recipeBook.Save(@"recipe.txt",@"ing5.txt");
            Assert.IsTrue(recipeBook.Load(@"recipe.txt",@"ing5.txt"));
        }
    }
}