using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class SubtractOperatorTests
    {
        [TestMethod()]
        public void SubtractOperatorTest()
        {
            string path = @"subtracttest.txt";
            File.WriteAllText(path, "8\n3");
            SubtractOperator subtract = new SubtractOperator(File.OpenText(path));
            Assert.AreEqual(subtract.Evaluate(), 5);
            Assert.AreEqual(subtract.ToString(), "(8-3)");
        }
    }
}