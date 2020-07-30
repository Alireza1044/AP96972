using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;
         /// <summary>
         /// this constructor (parent classes constructor) will be called by derived classes constructor
         /// and then creates Left-Hand-Side and Right-Hand-Side expressions which can be a number expression or another expression
         /// </summary>
         /// <param name="reader"></param>
        public BinaryOperator(TextReader reader)
        {
            this.LHS = Expression.BuildExpressionTree(reader);
            this.RHS = Expression.BuildExpressionTree(reader);
        }

        public abstract string OperatorSymbol { get; }

        /// <summary>
        /// creates the mathematical expression
        /// </summary>
        /// <returns> mathematical expression as a string </returns>
        public sealed override string ToString() => $"({LHS}{this.OperatorSymbol}{RHS})";

    }
}