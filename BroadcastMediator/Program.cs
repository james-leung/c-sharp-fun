using System;
using System.Collections.Generic;

namespace BroadcastMediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Participant
    {
        private readonly Mediator _mediator;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            _mediator = mediator;
            _mediator.Participants.Add(this);
        }

        public void Say(int n)
        {
            _mediator.Broadcast(this, n);
        }
    }

}
