using System;

namespace MathExpressionWithVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var expr = new MultiplicationExpression(
              new AdditionExpression(new Value(2), new Value(3)),
              new Value(4)
              );
            var ep = new ExpressionPrinter();
            ep.Visit(expr);
            Console.WriteLine($"Mathematical expression: {ep}");
        }
    }
}
