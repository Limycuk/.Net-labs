
using Bulbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behaviours
{
    public class OrangePulseBehaviour : Behaviour
    {
        public OrangePulseBehaviour(int index, List<Bulb> bulbs) : base(index, bulbs)
        {
        }

        protected override string[] States
        {
            get
            {
                return new string[] { "OrangePulse" };
            }
        }

        public override void NextState()
        {
            switch (States[Index % States.Length])
            {
                case "OrangePulse":
                    foreach (Bulb bulb in Bulbs)
                    {
                        if (bulb.Color == "Orange")
                        {
                            bulb.Pulse();
                        }
                        else
                        {
                            bulb.Off();
                        }
                    }
                    break;

            }
            Index++;
        }
    }
}
