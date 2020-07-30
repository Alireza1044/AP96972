using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        /// <summary>
        /// calls the build exrpession tree method and this will continue until 
        /// we only have a number and no other expressions
        /// </summary>
        /// <param name="reader"></param>
        public UnaryOperator(TextReader reader)
        {
            this.Operand = Expression.BuildExpressionTree(reader);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns> mathematical expression as a string </returns>
        public sealed override string ToString() => $"{this.OperatorSymbol}({this.Operand})";

        public abstract string OperatorSymbol { get; }
    }
}