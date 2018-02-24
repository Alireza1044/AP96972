using System;
using Xunit;

namespace unit_test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] gradesAsc = { 1, 2, 3, 6, 9 };
            int[] gradesDesc = { 11, 8, 5, 3, 1 };
            int[] gradesNeg = { 8, 5, 7, 6, 1 };

            Assert.True(Program.IsSorted(gradesAsc , true));
            Assert.True(Program.IsSorted(gradesDesc, false));
            Assert.True(Program.IsSorted(gradesNeg, false));

        }
    }
}
