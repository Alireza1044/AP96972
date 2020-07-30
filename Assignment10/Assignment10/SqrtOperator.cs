using System;
using System.IO;

namespace OOCalculator
{
    public class SqrtOperator : UnaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public SqrtOperator(TextReader reader)
            :base(reader)
        {
        }

        public override string OperatorSymbol => "Sqrt";

        /// <summary>
        /// 
        /// </summary>
        /// <returns>SquareRoot of the operand</returns>
        public override double Evaluate() => Math.Pow(Operand.Evaluate(),0.5);
    }
}