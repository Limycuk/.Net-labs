using Bulbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behaviours
{
    public class BehaviourFactory
    {
        public Behaviour CreateBehaviour(string type, int index, List<Bulb> bulbs)
        {
            Behaviour behaviour = null;

            if (type == "daily")
            {
                behaviour = new DailyBehaviour(index, bulbs);
            } else if (type == "orangePulse")
            {
                behaviour = new OrangePulseBehaviour(index, bulbs);
            }

            return behaviour;
        }
    }
}
