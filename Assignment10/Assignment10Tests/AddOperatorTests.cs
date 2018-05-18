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
    public class AddOperatorTests
    {
        [TestMethod()]
        public void AddOperatorTest()
        {
            StreamWriter writer;
            StreamReader reader;
            AddOperator plus;

            using (writer = new StreamWriter(@"writer.txt"))
            {
                writer.WriteLine("Add");
                writer.WriteLine("3");
                writer.WriteLine("5");
            }
            using (reader = new StreamReader(@"writer.txt"))
            {
                plus = new AddOperator(reader);
            }
            Assert.AreEqual(plus.LHS, 3);
            Assert.AreEqual(plus.RHS, 5);
            Assert.AreEqual(plus.Symbol, "Add");
        }

        [TestMethod()]
        public void EvaluateTest()
        {
            StreamWriter writer;
            StreamReader reader;
            AddOperator plus;

            using (writer = new StreamWriter(@"writer.txt"))
            {
                writer.WriteLine("Add");
                writer.WriteLine("3");
                writer.WriteLine("5");
            }
            using (reader = new StreamReader(@"writer.txt"))
            {
                plus = new AddOperator(reader);
            }
            Assert.AreEqual(8, plus.Evaluate());
            Assert.AreEqual("+", plus.OperatorSymbol);
        }
    }
}