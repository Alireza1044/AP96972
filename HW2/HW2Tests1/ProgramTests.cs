using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void EnteranceTest()
        {
            int[] Test1 = new int[] { 1, 1, 1, 2, 2, 2, 4, 4 };
            int[] Test2 = new int[] { 8, 8, 8, 8, 8, 8, 8, 8 };
            int[] Test3 = new int[] { 1, 1, 1, 1, 6, 6, 6, 6 };
            Assert.AreEqual(0.375, Program.Entrance(1, 0, Test1), 0);
            Assert.AreEqual(0.25, Program.Entrance(4, 0, Test1), 0);
            Assert.AreEqual(0, Program.Entrance(1, 0, Test2), 0);
            Assert.AreEqual(1, Program.Entrance(8, 0, Test2), 0);
            Assert.AreEqual(0.5, Program.Entrance(6, 0, Test3), 0);
        }
    }
}