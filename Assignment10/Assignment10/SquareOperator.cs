using System;
using System.IO;

namespace OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        /// <summary>
        /// receives a textreader and calls the base class constructor
        /// </summary>
        /// <param name="reader"></param>
        public SquareOperator(TextReader reader)
            :base(reader)
        {
        }

        public override string OperatorSymbol => "Square";

        /// <summary>
        /// 
        /// </summary>
        /// <returns> square of the operand </returns>
        public override double Evaluate() => Math.Pow(Operand.Evaluate(),2);

    }
}