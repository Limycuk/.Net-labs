using Bulbs;
using System;
using System.Collections.Generic;

namespace Behaviours
{
    abstract public class Behaviour
    {
        public Behaviour(int index, List<Bulb> bulbs)
        {
            Index = index;
            Bulbs = bulbs;
        }
        protected int Index { get; set; }
        abstract protected string[] States { get; }
        protected List<Bulb> Bulbs { get; set; }
        public abstract void NextState();
    }
}
