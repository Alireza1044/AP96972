using System;

namespace SimpleCalculator
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// this is the first state when the calculator starts
    /// this state prevents enter more than one 0 when there's no other numbers
    /// when the user enters a number other than 0 we save the number to Calc.Display
    /// and the calculator goes to Accumulate State
    /// and when the user enters a double number the calculator enters Point State
    /// which prevents the user from entering more than one '.'
    /// when the user enters '=' the calculator enters compute state
    /// to prevent the user from entering more than one '=' and then shows the result
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }

        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));

        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }

        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) => 
            ProcessOperator(new StartState(this.Calc), c);

        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}