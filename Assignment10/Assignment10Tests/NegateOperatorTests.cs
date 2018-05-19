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
    public class NegateOperatorTests
    {
        [TestMethod()]
        public void NegateOperatorTest()
        {
            string path = @"negatetest.txt";
            File.WriteAllText(path, "9");
            NegateOperator negate = new NegateOperator(File.OpenText(path));
            Assert.AreEqual(negate.Evaluate(), -9);
            Assert.AreEqual(negate.ToString(), "-(9)");
        }
    }
}