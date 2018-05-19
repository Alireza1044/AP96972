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
    public class ExpressionTests
    {
        [TestMethod()]
        public void BuildExpressionTreeTest()
        {
            string path = @"expressiontests.txt";
            File.WriteAllText(path, 
                "Multiply\n" +
                "6\n" +
                "Subtract\n" +
                "Negate\n" +
                "5\n" +
                "Add\n" +
                "3\n" +
                "Divide\n" +
                "10\n" +
                "Add\n" +
                "1\n" +
                "Add\n" +
                "SquareRoot\n" +
                "9\n" +
                "Square\n" +
                "4"
                );
            Assert.AreEqual(Expression.BuildExpressionTree(File.OpenText(path)).Evaluate(), -51);
            //Assert.AreEqual(Expression.BuildExpressionTree(File.OpenText(path)).ToString(),"-5*(3+(10/(1+Square(3))))");
        }
    }
}