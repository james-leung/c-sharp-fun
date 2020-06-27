using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = "32+a-52+a";
            var dict = new Dictionary<char, int>();
            dict.Add('a', 2);
            var lexer = new Lexer(expression, dict);
            var tokens = lexer.Lex();

            foreach (var token in tokens)
                Console.WriteLine($"{token.Type}, {token.Value}");

            var variables = new Dictionary<char, int>();
            variables.Add('a', 2);

            var processor = new ExpressionProcessor(variables);
            Console.WriteLine($"The sum of {expression} is {processor.Calculate(expression)}");
        }
    }


    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();
        public ExpressionProcessor(Dictionary<char, int> variables)
        {
            Variables = variables;
        }
        public int Calculate(string expression)
        {
            var lexer = new Lexer(expression, Variables);
            var tokens = lexer.Lex();
            var sum = tokens[0].Value;
            if (tokens.Any(t => t.Type == TokenType.Invalid))
                return 0;
            else
            {
                int j = 0;
                while (j + 2 < tokens.Count)
                {
                    if (tokens[j + 1].Type == TokenType.Plus)
                    {
                        sum += tokens[j + 2].Value;
                    }
                    else if (tokens[j + 1].Type == TokenType.Minus)
                    {
                        sum -= tokens[j + 2].Value;
                    }
                    j += 2;
                }
            }
            return sum;
        }

    }
}
