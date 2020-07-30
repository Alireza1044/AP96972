using System;
using System.IO;

namespace OOCalculator
{
    public class NegateOperator : UnaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public NegateOperator(TextReader reader)
            :base(reader)
        {
        }

        public override string OperatorSymbol => "-";

        /// <summary>
        /// counts the operand
        /// </summary>
        /// <returns> the negate of the operand </returns>
        public override double Evaluate() => -1 * Operand.Evaluate(); 
    }
}