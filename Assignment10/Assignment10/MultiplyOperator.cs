using System;
using System.IO;

namespace OOCalculator
{
    public class MultiplyOperator : BinaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public MultiplyOperator(TextReader reader)
            :base(reader)
        {
        }

        public override string OperatorSymbol => "*";
        
        /// <summary>
        /// counts LHS & RHS
        /// </summary>
        /// <returns> the square of the LHS & RHS </returns>
        public override double Evaluate() => (LHS.Evaluate()*RHS.Evaluate());
    }
}