﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ButtonAdapter
{
    public interface ICommand
    {
        void Execute();
    }

    public class Button
    {
        private ICommand command;
        private string name;

        public Button(ICommand command, string name)
        {
            if (command == null)
            {
                throw new ArgumentNullException(paramName: nameof(command));
            }
            this.command = command;
            this.name = name;
        }

        public void Click()
        {
            command.Execute();
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called {name}");
        }
    }
}
