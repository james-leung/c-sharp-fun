using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Interpreter
{
    public class Lexer
    {
        private readonly string _inputStr;
        private readonly Dictionary<char, int> _variables;

        public Lexer(string inputStr, Dictionary<char, int> variables)
        {
            _inputStr = inputStr;
            _variables = variables;
        }
        public List<Token> Lex()
        {
            var result = new List<Token>();

            for (int i = 0; i < _inputStr.Length; i++)
            {
                switch (_inputStr[i])
                {
                    case '+':
                        result.Add(new Token(TokenType.Plus));
                        break;
                    case '-':
                        result.Add(new Token(TokenType.Minus));
                        break;
                    case var x when new Regex(@"[a-z]").IsMatch(x.ToString()):
                        if (i + 1 < _inputStr.Length && new Regex(@"[a-z]").IsMatch(_inputStr[i + 1].ToString()))
                            result.Add(new Token(TokenType.Invalid));
                        else if (_variables.ContainsKey(x))
                            result.Add(new Token(TokenType.Integer, _variables[x]));
                        else
                            result.Add(new Token(TokenType.Invalid));
                        break;
                    case var x when char.IsDigit(_inputStr[i]):
                        var s = x.ToString();
                        if (i == _inputStr.Length - 1)
                        {
                            result.Add(new Token(TokenType.Integer, int.Parse(s)));
                            break;
                        }
                        for (int j = i + 1; j < _inputStr.Length; j++)
                        {
                            if (char.IsDigit(_inputStr[j]))
                            {
                                s += _inputStr[j];
                                i++;
                                if (j == _inputStr.Length - 1)
                                    result.Add(new Token(TokenType.Integer, int.Parse(s)));
                            }
                            else
                            {
                                result.Add(new Token(TokenType.Integer, int.Parse(s)));
                                break;
                            }
                        }
                        break;
                    default:
                        result.Add(new Token(TokenType.Invalid));
                        break;
                }
            }
            return result;
        }
    }
}
