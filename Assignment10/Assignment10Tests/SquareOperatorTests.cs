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
            StreamWriter writer;
            StreamReader reader;
            SquareOperator square;

            using (writer = new StreamWriter(@"writer.txt"))
            {
                writer.WriteLine("Square");
                writer.WriteLine("3");
            }

            using (reader = new StreamReader(@"writer.txt"))
            {
                square = new SquareOperator(reader);
            }
            Assert.AreEqual(square.LHS, 3);
            Assert.AreEqual(square.Symbol, "Square");
            Assert.AreEqual(square.OperatorSymbol, "Square");
        }

        [TestMethod()]
        public void EvaluateTest()
        {
            StreamWriter writer;
            StreamReader reader;
            SquareOperator square;

            using (writer = new StreamWriter(@"writer.txt"))
            {
                writer.WriteLine("Square");
                writer.WriteLine("6");
            }

            using (reader = new StreamReader(@"writer.txt"))
            {
                square = new SquareOperator(reader);
            }
            Assert.AreEqual(square.Evaluate(), 36);
        }
    }
}