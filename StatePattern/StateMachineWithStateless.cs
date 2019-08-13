using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithStateless
{
    public enum Health
    {
        NonReproductive,
        Pregnant,
        Reproductive
    }

    public enum Activity
    {
        GiveBirth,
        ReachPuberty,
        HaveAbortion,
        HaveUnprotectedSex,
        Historectomy
    }

    class StateMachineWithStateless
    {
        public static bool parentsNotWatching { get; set; }

        void Main(string[] args)
        {
            var stateMachine = new StateMachine<Health, Activity>(Health.NonReproductive);
            stateMachine.Configure(Health.NonReproductive)
                .Permit(Activity.ReachPuberty, Health.Reproductive);
            stateMachine.Configure(Health.Reproductive)
            .Permit(Activity.Historectomy, Health.NonReproductive)
            .PermitIf(Activity.HaveUnprotectedSex, Health.Pregnant,
                () => parentsNotWatching);
            stateMachine.Configure(Health.Pregnant)
              .Permit(Activity.GiveBirth, Health.Reproductive)
              .Permit(Activity.HaveAbortion, Health.Reproductive);

        }
    }
}
