using SimpleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AccumulateStateTest() => RunTest<AccumulateState>(keys: "123430q", expectedDisplay: "123430");

        [TestMethod()]
        public void PointStateTest() => RunTest<PointState>(keys: ".......q", expectedDisplay: "0.");

        [TestMethod()]
        public void StartStateTest() => RunTest<StartState>(keys: "12+q", expectedDisplay: "12");

        [TestMethod()]
        public void ErrorStateTest() => RunTest<ErrorState>(keys: "12+5==q", expectedDisplay: "17");

        [TestMethod()]
        public void SumTest() => RunTest<ComputeState>(keys: "10+10=q", expectedDisplay: "20");

        [TestMethod()]
        public void ZeroTest() => RunTest<StartState>(keys: "000000q", expectedDisplay: "0");

        [TestMethod()]
        public void ExtraPointTest() => RunTest<PointState>(keys: "55.234.2q", expectedDisplay: "55.2342");

        [TestMethod()]
        public void MultiplyTest() => RunTest<ComputeState>(keys: "10*10=q", expectedDisplay: "100");

        [TestMethod()]
        public void MultipleSumTest() => RunTest<ComputeState>(keys: "10+10+10.3=q", expectedDisplay: "30.3");

        [TestMethod()]
        public void DivideTest() => RunTest<ComputeState>(keys: "10/2=q", expectedDisplay: "5");

        [TestMethod()]
        public void AccumulationTest() => RunTest<AccumulateState>(keys: "10q", expectedDisplay: "10");

        [TestMethod()]
        public void StartingPointTest() => RunTest<ComputeState>(keys: ".5*2=q", expectedDisplay: "1");

        [TestMethod()]
        public void ComputeStateTest1() => RunTest<ComputeState>(keys: ".5*2=/10=q", expectedDisplay: "0.1");

        [TestMethod()]
        public void ComputeStateTest2() => RunTest<ComputeState>(keys: ".5*2=10=0=q", expectedDisplay: "0");

        [TestMethod()]
        public void ComputeStateTest3() => RunTest<ComputeState>(keys: ".5*2=.1.1=q", expectedDisplay: "0.11");

        [TestMethod()]
        public void StartStateTest1() => RunTest<ComputeState>(keys: "+6=q", expectedDisplay: "6");

        [TestMethod()]
        public void ProgramTest() => RunTest<StartState>(keys: "cq", expectedDisplay: "0");

        [TestMethod()]
        public void ComputeStateTest4() => RunTest<ComputeState>(keys: "5^2=-3=q", expectedDisplay: "22");

        [TestMethod()]
        public void ErrorStateTest2() => RunTest<StartState>(keys: "12+5==0q", expectedDisplay: "17");

        [TestMethod()]
        public void ErrorStateTest3() => RunTest<StartState>(keys: "12+5===q", expectedDisplay: "17");

        [TestMethod()]
        public void ErrorStateTest4() => RunTest<StartState>(keys: "12+5==1q", expectedDisplay: "17");

        [TestMethod()]
        public void ErrorStateTest5() => RunTest<StartState>(keys: "12+5==.q", expectedDisplay: "17");

        [TestMethod()]
        public void ErrorStateTest6() => RunTest<StartState>(keys: "12+5==+q", expectedDisplay: "17");


        private void RunTest<ExpectedState>(string keys, string expectedDisplay)
        {
            int i = 0;
            Calculator c = Program.RunCalculator(() => keys[i++], () => { });
            Assert.AreEqual(c.Display, expectedDisplay); 
            Assert.IsTrue(c.State is ExpectedState);
        }

    }
}