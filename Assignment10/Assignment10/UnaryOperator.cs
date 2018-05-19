﻿using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator(TextReader reader)
        {
            this.Operand = Expression.BuildExpressionTree(reader);
        }

        public sealed override string ToString() => $"{this.OperatorSymbol}({this.Operand})";

        public abstract string OperatorSymbol { get; }
    }
}