﻿using static System.Console;

namespace SimpleCalculator
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual() => null;
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            this.Calc.Display += c;
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c) => null;

        public override IState EnterPoint()
        {
            // #10 لطفا!
            return null;
        }
    }
}