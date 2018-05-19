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
    public class DivideOperatorTests
    {
        [TestMethod()]
        public void DivideOperatorTest()
        {
            string path = @"dividetest.txt";
            File.WriteAllText(path, "9\n2");
            DivideOperator divide = new DivideOperator(File.OpenText(path));
            Assert.AreEqual(divide.Evaluate(), 4.5);
            Assert.AreEqual(divide.ToString(), "(9/2)");
        }
    }
}