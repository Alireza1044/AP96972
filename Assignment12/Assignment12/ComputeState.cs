namespace SimpleCalculator
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        /// <summary>
        /// when we are in this state and the user enters '=' we show an error because
        /// we have already shown the result
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        /// <summary>
        /// we start storing the number like the begining when the user enters a number other than '0'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            // #3 لطفا!
            return new AccumulateState(this.Calc).EnterNonZeroDigit(c);
        }

        /// <summary>
        /// we go to start state when the user enters a '0' because there cannot be more than one '0'
        /// after we enter this state and start entering a new number
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            return new StartState(this.Calc).EnterZeroDigit();
        }

        // #5 لطفا
        /// <summary>
        /// when the user enters an operator we save the number to accumulation 
        /// and update the display and then enter the Start State so user can enter a new number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => ProcessOperator(new StartState(Calc),c);

        /// <summary>
        /// we go to point state after the user enters a double number as usual
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}