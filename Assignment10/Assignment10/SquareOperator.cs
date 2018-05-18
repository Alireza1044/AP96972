using System;
using System.IO;

namespace OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        public string Symbol;
        public int LHS;

        public SquareOperator(TextReader reader)
            :base()
        {
            Symbol =reader.ReadLine();
            LHS = int.Parse(reader.ReadLine());

        }

        public override string OperatorSymbol => "Square";

        public override double Evaluate() => (LHS*LHS);

    }
}