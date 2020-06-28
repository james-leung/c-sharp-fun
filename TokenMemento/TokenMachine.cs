using System.Collections.Generic;
using System.Linq;

namespace TokenMemento
{
    public class Memento
    {
        public List<Token> Tokens = new List<Token>();

        public Memento(List<Token> tokens)
        {
            //tokens.ForEach(t => Tokens.Add(new Token(t.Value)));
            Tokens = tokens.Select(t => new Token(t.Value)).ToList();
        }
    }

    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }
    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));
            return new Memento(Tokens);
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return new Memento(Tokens);
        }

        public void Revert(Memento m)
        {
            Tokens = m.Tokens;
        }
    }
}
