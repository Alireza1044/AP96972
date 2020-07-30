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
            string path = @"addtest";
            File.WriteAllText(path, "5\n3");
            AddOperator add = new AddOperator(File.OpenText(path));
            Assert.AreEqual(add.Evaluate(), 8);
            Assert.AreEqual(add.ToString(), "(5+3)");
        }
    }
}