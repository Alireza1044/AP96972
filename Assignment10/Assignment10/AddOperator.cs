using System;
using System.IO;

namespace OOCalculator
{
    public class AddOperator : BinaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public AddOperator(TextReader reader) 
            :base(reader)
        {
        }

        public override string OperatorSymbol => "+";

        /// <summary>
        /// counts Left-Hand-Side & Right-Hand-Side
        /// </summary>
        /// <returns> the result as double </returns>
        public override double Evaluate() => (LHS.Evaluate()+RHS.Evaluate());
    }
}