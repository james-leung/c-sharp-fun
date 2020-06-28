using System.Collections.Generic;

namespace BroadcastMediator
{
    public class Mediator
    {
        public List<Participant> Participants = new List<Participant>();
        public void Broadcast(Participant participant, int n)
        {
            foreach (var p in Participants)
            {
                if (p != participant)
                {
                    p.Value += n;
                }
            }
        }
    }
}
