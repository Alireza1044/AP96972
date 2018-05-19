using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator()
        {

        }

        public UnaryOperator(TextReader reader)
        {
            this.Operand = Expression.BuildExpressionTree(reader);
        }

        public sealed override string ToString() => $"{this.OperatorSymbol}({this.Operand.Evaluate()})";

        public abstract string OperatorSymbol { get; }
    }
}