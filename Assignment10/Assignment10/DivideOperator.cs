using System;
using System.IO;

namespace OOCalculator
{
    public class DivideOperator : BinaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public DivideOperator(TextReader reader)
            :base(reader)
        {
        }

        public override string OperatorSymbol => "/";

        /// <summary>
        /// 
        /// </summary>
        /// <returns> divide of LHS & RHS </returns>
        public override double Evaluate() => (LHS.Evaluate()/RHS.Evaluate());
    }
}