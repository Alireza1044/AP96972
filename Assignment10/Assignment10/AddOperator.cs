using System;
using System.IO;

namespace OOCalculator
{
    public class AddOperator : BinaryOperator
    {
        public string Symbol;
        public int LHS;
        public int RHS;

        public AddOperator(TextReader reader) 
            :base()
        {
            Symbol = reader.ReadLine();
            LHS = int.Parse(reader.ReadLine());
            RHS = int.Parse(reader.ReadLine());
        }

        public override string OperatorSymbol => "+";

        public override double Evaluate() => (LHS+RHS);
    }
}