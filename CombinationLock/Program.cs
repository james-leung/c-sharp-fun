using System;
using System.Linq;

namespace CombinationLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Lock status = {cl.Status}");
            cl.EnterDigit(1);
            Console.WriteLine($"Lock status = {cl.Status}");
            cl.EnterDigit(2);
            Console.WriteLine($"Lock status = {cl.Status}");
            cl.EnterDigit(3);
            Console.WriteLine($"Lock status = {cl.Status}");
            cl.EnterDigit(4);
            Console.WriteLine($"Lock status = {cl.Status}");
            cl.EnterDigit(5);
            Console.WriteLine($"Lock status = {cl.Status}");
        }
    }

    public class CombinationLock
    {
        public CombinationLock(int[] combination)
        {
            _combination = combination;
            Status = "LOCKED";
        }

        // you need to be changing this on user input
        public string Status;
        private readonly int[] _combination;
        private string _userInput = "";

        public void EnterDigit(int digit)
        {
            _userInput += digit.ToString();
            if (_userInput.Length < _combination.Length)
                Status = _userInput;
            if (_userInput.Length == _combination.Length)
            {
                bool match = string.Join("", _combination.Select(d => d.ToString())) == _userInput;
                Status = match ? "OPEN" : "ERROR";
            }
        }
    }
}
