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
    public class SqrtOperatorTests
    {
        [TestMethod()]
        public void SqrtOperatorTest()
        {
            string path = @"sqrttests.txt";
            File.WriteAllText(path, "9");
            SqrtOperator sqrt = new SqrtOperator(File.OpenText(path));
            Assert.AreEqual(sqrt.Evaluate(), 3);
            Assert.AreEqual(sqrt.ToString(), "Sqrt(9)");
        }
    }
}