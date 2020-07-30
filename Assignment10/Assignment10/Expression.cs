using System;
using System.IO;

namespace OOCalculator
{
    public abstract class Expression
    {
        public abstract double Evaluate();

        /// <summary>
        /// this methode will build the mathematical expression and
        /// it will get more complete each time a derived class is used
        /// </summary>
        /// <param name="reader"></param>
        /// <returns> the expressions until the end </returns>
        public static Expression BuildExpressionTree(TextReader reader)
        {
            return Expression.GetNextExpression(reader);
        }
        
        /// <summary>
        /// this method will call the derived classes and builds the mathematical expressions
        /// each time it runs
        /// </summary>
        /// <param name="reader"></param>
        /// <returns> each expression until we have a number expression and no other operators </returns>
        protected static Expression GetNextExpression(TextReader reader)
        {
            string line = reader.ReadLine();
            switch (line)
            {
                case "Add":
                    return new AddOperator(reader);

                case "Subtract":
                    return new SubtractOperator(reader);

                case "Multiply":
                    return new MultiplyOperator(reader);

                case "Negate":
                    return new NegateOperator(reader);

                case "Square":
                    return new SquareOperator(reader);

                case "Divide":
                    return new DivideOperator(reader);

                case "SquareRoot":
                    return new SqrtOperator(reader);

                default:
                    return new NumberExpression(line);

            }
        }
    }
}