using System;
using System.Threading;
using System.Windows;

namespace GameWithObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var rat1 = new Rat(game);
            Console.WriteLine($"{rat1.Attack}");
            var rat2 = new Rat(game);
            Console.WriteLine($"{rat1.Attack}");
            Console.WriteLine($"{rat2.Attack}");
            using (var rat3 = new Rat(game))
            {
                Console.WriteLine($"{rat1.Attack}");
                Console.WriteLine($"{rat2.Attack}");
                Console.WriteLine($"{rat3.Attack}");
            }
            Console.WriteLine($"{rat1.Attack}");
            Console.WriteLine($"{rat2.Attack}");
        }
    }

    public class UpdateAttackArgs
    {
        public UpdateAttackArgs(Rat rat, int attackValue)
        {
            Rat = rat;
            AttackValue = attackValue;
        }

        public Rat Rat { get; }
        public int AttackValue { get; }
    }

    public class ModifyAttackArgs
    {
        public ModifyAttackArgs(Rat rat, int attackChange)
        {
            Rat = rat;
            AttackChange = attackChange;
        }

        public Rat Rat { get; }
        public int AttackChange { get; }
    }

    public class Game
    {
        public event EventHandler<ModifyAttackArgs> ModifyAttackEvent;
        public event EventHandler<UpdateAttackArgs> UpdateAttackEvent;
        public void ModifyAttack(ModifyAttackArgs mea)
        {
            ModifyAttackEvent?.Invoke(this, mea);
        }

        public void UpdateAttack(UpdateAttackArgs uea)
        {
            UpdateAttackEvent?.Invoke(this, uea);
        }
    }

    public class Rat : IDisposable
    {
        private readonly Game _game;
        public int Attack = 1;

        public Rat(Game game)
        {
            game.ModifyAttackEvent += ModifyRatAttack;
            game.UpdateAttackEvent += UpdateRatAttack;
            game.ModifyAttack(new ModifyAttackArgs(this, 1));
            _game = game;
        }

        public void UpdateRatAttack(object sender, UpdateAttackArgs uaa)
        {
            if (uaa.Rat == this)
            {
                Attack = uaa.AttackValue;
            }
        }

        public void ModifyRatAttack(object sender, ModifyAttackArgs maa)
        {
            if (maa.Rat != this)
            {
                Attack += maa.AttackChange;
                _game.UpdateAttack(new UpdateAttackArgs(maa.Rat, Attack));
            }
        }

        public void Dispose()
        {
            _game.ModifyAttack(new ModifyAttackArgs(this, -1));
            _game.ModifyAttackEvent -= ModifyRatAttack;
            _game.UpdateAttackEvent -= UpdateRatAttack;
        }
    }
}
