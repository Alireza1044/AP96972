﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class IngredientTests
    {
        [TestMethod()]
        public void IngredientTest()
        {
            Ingredient ingredient = new Ingredient("ingredient name", "ingredient description", 2.8, "gr");
            Assert.AreEqual(ingredient.Name, "ingredient name");
            Assert.AreEqual(ingredient.Description, "ingredient description");
            Assert.AreEqual(ingredient.Unit, "gr");
            Assert.AreEqual(ingredient.Quantity, 2.8);
        }

        [TestMethod()]
        public void SerializeTest()
        {
            Ingredient ing = new Ingredient("ing1", "use with water", 2.1, "kg");
            string name;
            string description;
            double quantity;
            string unit;
            StreamWriter writer;
            using (writer = new StreamWriter(@"ing1.txt", false, Encoding.UTF8))
            {
                ing.Serialize(writer);
            }
            using (StreamReader reader = new StreamReader(@"ing1.txt"))
            {
                name = reader.ReadLine();
                description = reader.ReadLine();
                quantity = double.Parse(reader.ReadLine());
                unit = reader.ReadLine();
                //writer.Close();
                //writer.Dispose();
                //reader.Close();
                //reader.Dispose();
            }
            Assert.AreEqual(ing.Name, name);
            Assert.AreEqual(ing.Description, description);
            Assert.AreEqual(ing.Quantity, quantity);
            Assert.AreEqual(ing.Unit, unit);
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            Ingredient ing1;
            Ingredient ing2;
            Ingredient ing = new Ingredient("name", "desc", 2.1, "gr");
            using (StreamWriter writer = new StreamWriter(@"ing2.txt"))
            {
                ing.Serialize(writer);
            }
            using (StreamReader reader = new StreamReader(@"ing2.txt"))
            {
                ing1 = Ingredient.Deserialize(reader, @"ing2.txt");
            }
            using (StreamReader reader = new StreamReader(@"ing2.txt"))
            {
                ing2 = Ingredient.Deserialize(reader, @"w2fmk.txt");
            }
            Assert.IsNull(ing2);
            Assert.AreEqual(ing.Name, ing1.Name);
            Assert.AreEqual(ing.Quantity, ing1.Quantity);
            Assert.AreEqual(ing.Description, ing1.Description);
            Assert.AreEqual(ing.Unit, ing1.Unit);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Ingredient ing = new Ingredient("name", "desc", 2.5, "kg");
            string inginfo = ing.ToString();
            Assert.AreEqual(inginfo, $"{ing.Name}:\t{ing.Quantity} {ing.Unit} - {ing.Description}");
        }
    }
}