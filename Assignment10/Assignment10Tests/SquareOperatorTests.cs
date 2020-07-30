using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class SquareOperatorTests
    {
        [TestMethod()]
        public void SquareOperatorTest()
        {
            string path = @"squaretest.txt";
            File.WriteAllText(path, "5");
            SquareOperator square = new SquareOperator(File.OpenText(path));
            Assert.AreEqual(square.Evaluate(), 25);
            Assert.AreEqual(square.ToString(), "Square(5)");
        }
    }
}