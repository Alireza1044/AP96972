using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ProbabilityCounterFuncTest()
        {
            int[] Test1 = new int[] { 1, 1, 1, 2, 2, 2, 4, 4 };
            int[] Test2 = new int[] { 8, 8, 8, 8, 8, 8, 8, 8 };
            int[] Test3 = new int[] { 1, 1, 1, 1, 6, 6, 6, 6 };
            Assert.AreEqual(0.375, Program.ProbabilityCounterFunc(1, Test1), 0);
            Assert.AreEqual(0.25, Program.ProbabilityCounterFunc(4, Test1), 0);
            Assert.AreEqual(0, Program.ProbabilityCounterFunc(1, Test2), 0);
            Assert.AreEqual(1, Program.ProbabilityCounterFunc(8, Test2), 0);
            Assert.AreEqual(0.5, Program.ProbabilityCounterFunc(6, Test3), 0);
        }

        [TestMethod()]
        public void inputTest()
        {
            const string input = "1 2 3 4 5 6 7 8";
            using (StringWriter writer = new StringWriter())
            using (StringReader reader = new StringReader(input))
            {
                Program.input(reader);
            }
        }

        [TestMethod()]
        public void outputTest()
        {
            const string input = "1 2 3 4 5 6 7 8";
            int[] TestArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (StringWriter writer = new StringWriter())
            using (StringReader reader = new StringReader(input))
            {
                Program.output(1 , TestArray , writer);
            }
        }
    }
}