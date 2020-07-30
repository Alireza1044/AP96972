using System;
using System.IO;

namespace OOCalculator
{
    public class SubtractOperator : BinaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public SubtractOperator(TextReader reader)
            :base(reader)
        {
        }

        public override string OperatorSymbol => "-";

        /// <summary>
        /// 
        /// </summary>
        /// <returns> subtract of the count of LHS & RHS </returns>
        public override double Evaluate() => (LHS.Evaluate() - RHS.Evaluate());
    }
}