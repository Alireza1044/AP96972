using System;
using System.IO;

namespace OOCalculator
{
    public class NumberExpression : Expression
    {
        protected double Number;
         /// <summary>
         /// parses the expression if it is a number
         /// </summary>
         /// <param name="line"></param>
        public NumberExpression(string line)
        {
            Number = double.Parse(line);
        }

        public override double Evaluate() => Number;

        /// <summary>
        /// 
        /// </summary>
        /// <returns> the number expression as string </returns>
        public override string ToString() => $"{Number}";
    }
}