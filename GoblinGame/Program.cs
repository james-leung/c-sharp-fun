using System;
using System.Collections.Generic;
using System.Linq;

namespace GoblinGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Game();
            var goblin1 = new Goblin(g);
            var goblin2 = new Goblin(g);
            var goblinKing = new GoblinKing(g);
            g.Creatures.Add(goblin1);
            g.Creatures.Add(goblin2);
            g.Creatures.Add(goblinKing);

            Console.WriteLine($"Game created with 2 creatures ");
            Console.WriteLine($"A goblin has attack {goblin1.Attack}, defense {goblin1.Defense}.");
        }
    }

    public abstract class Creature
    {
        protected Game _game;
        protected int _attack;
        protected int _defense;
        protected int _attackBonus = 0;
        protected int _defenseBonus = 0;
        public int Attack
        {
            get
            {
                var modifiedAttack = _attack;
                foreach (var c in _game.Creatures)
                    modifiedAttack += c._attackBonus;
                return modifiedAttack - _attackBonus;
            }
            set => _attack = value;
        }

        public int Defense
        {
            get
            {
                var modifiedDefense = _defense;
                foreach (var c in _game.Creatures)
                    modifiedDefense += c._defenseBonus;
                return modifiedDefense - _defenseBonus;
            }
            set => _defense = value;
        }
    }

    public class Goblin : Creature
    {
        public Goblin(Game game)
        {
            _attack = 1;
            _defense = 1;
            _defenseBonus = 1;
            _game = game;
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game)
        {
            _attack = 3;
            _defense = 3;
            _attackBonus = 1;
            _game = game;
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }
}
