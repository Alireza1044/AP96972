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
    public class MultiplyOperatorTests
    {
        [TestMethod()]
        public void MultiplyOperatorTest()
        {
            string path = "Multiplytest.txt";
            File.WriteAllText(path, "5\n2");
            MultiplyOperator multiply = new MultiplyOperator(File.OpenText(path));
            Assert.AreEqual(multiply.Evaluate(), 10);
            Assert.AreEqual(multiply.ToString(), "(5*2)");
        }
    }
}