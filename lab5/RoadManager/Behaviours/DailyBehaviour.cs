
using Bulbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behaviours
{
    public class DailyBehaviour : Behaviour
    {
        public DailyBehaviour(int index, List<Bulb> bulbs) : base(index, bulbs)
        {
        }

        protected override string[] States
        {
            get
            {
                return new string[] { "Green", "GreenPulse", "Orange", "Red", "RedOrange" };
            }
        }

        public override void NextState()
        {
            switch(States[Index % States.Length])
            {
                case "Green":
                    foreach(Bulb bulb in Bulbs)
                    {
                        if (bulb.Color == "Green")
                        {
                            bulb.On();
                        } else
                        {
                            bulb.Off();
                        }
                    }
                    break;
                case "GreenPulse":
                    foreach (Bulb bulb in Bulbs)
                    {
                        if (bulb.Color == "Green")
                        {
                            bulb.Pulse();
                        }
                        else
                        {
                            bulb.Off();
                        }
                    }
                    break;
                case "Orange":
                    foreach (Bulb bulb in Bulbs)
                    {
                        if (bulb.Color == "Orange")
                        {
                            bulb.On();
                        }
                        else
                        {
                            bulb.Off();
                        }
                    }
                    break;
                case "Red":
                    foreach (Bulb bulb in Bulbs)
                    {
                        if (bulb.Color == "Red")
                        {
                            bulb.On();
                        }
                        else
                        {
                            bulb.Off();
                        }
                    }
                    break;
                case "RedOrange":
                    foreach (Bulb bulb in Bulbs)
                    {
                        if (bulb.Color == "Red" || bulb.Color == "Orange")
                        {
                            bulb.On();
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
