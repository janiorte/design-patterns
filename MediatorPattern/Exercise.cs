using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Participant
    {
        public int Value { get; set; }
        private Mediator Mediator { get; set; }

        public Participant(Mediator mediator)
        {
            Mediator = mediator;
            Mediator.Participants.Add(this);
        }

        public void Say(int n)
        {
            foreach (var participant in Mediator.Participants)
            {
                if(participant != this)
                {
                    participant.Value += n;
                }
            }
        }
    }

    public class Mediator
    {
        public List<Participant> Participants = new List<Participant>();
    }
}