using System;
using System.Collections.Generic;
using System.Text;

namespace ButtonAdapter
{
    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving current file");
        }
    }

    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }
}
