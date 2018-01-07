using System;

namespace Bulbs
{
    abstract public class Bulb
    {
        enum States { Off, On, Pulse }
        States State { get; set; } = States.Off;
        abstract public string Color { get; }
        public void On()
        {
            State = States.On;
        }

        public void Off()
        {
            State = States.Off;
        }

        public void Pulse()
        {
            State = States.Pulse;
        }
    }
}
