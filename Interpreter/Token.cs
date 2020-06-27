using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public enum TokenType
    {
        Plus,
        Minus,
        Integer,
        Variable,
        Invalid
    }

    public class Token
    {
        public Token(TokenType type, int value = 0)
        {
            Type = type;
            Value = value;
        }
        public TokenType Type { get; }
        public int Value { get; }
    }
}
