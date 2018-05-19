using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;
        
        public BinaryOperator()
        {
        }

        public BinaryOperator(TextReader reader)
        {
            this.LHS = Expression.BuildExpressionTree(reader);
            this.RHS = Expression.BuildExpressionTree(reader);
        }

        public abstract string OperatorSymbol { get; }

        public sealed override string ToString() => $"({LHS.Evaluate()}{this.OperatorSymbol}{RHS.Evaluate()})";

    }
}