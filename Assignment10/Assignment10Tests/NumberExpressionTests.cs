using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class NumberExpressionTests
    {
        [TestMethod()]
        public void NumberExpressionTest()
        {
            string numbertest = "5";
            NumberExpression number = new NumberExpression(numbertest);
            Assert.AreEqual(number.ToString(), "5");
        }
    }
}