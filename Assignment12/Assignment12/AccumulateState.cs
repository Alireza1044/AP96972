using static System.Console;

namespace SimpleCalculator
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        /// <summary>
        /// when the user enters '=' the calculator shows the result and goes to enters compute state
        /// prevent the user from entering more '='
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual() => ProcessOperator(new ComputeState(Calc));

        /// <summary>
        /// when the user enters a '0' the calculator acts like it's  a number other than zero
        /// and calls the EnterNonZero method
        /// because there's no need to prevent the user from entering more '0'
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');

        /// <summary>
        /// when we are in Accumulate state we are storing the numbers in Calc.Display
        /// so when the user enters a number we call this mehtod to add the number to the other numbers
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            this.Calc.Display += c;
            return this;
        }

        // #9 لطفا!
        /// <summary>
        /// when the user enters an operator the calculator adds the previous number to accumulation
        /// and updates the Calc.Display and then goes to start state in order for the user to enter a new number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => ProcessOperator(new StartState(Calc),c);

        /// <summary>
        /// when the user enters a double number the calculator enters point state to prevent the user from entering more '.'
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            // #10 لطفا!
            this.Calc.Display += '.';
            return new PointState(Calc);
        }
    }
}