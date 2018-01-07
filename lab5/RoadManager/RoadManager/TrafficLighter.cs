using Behaviours;
using Bulbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadManager
{
    public class TrafficLighter
    {
        public List<Bulb> Bulbs { get; private set; }
        public Behaviour Behaviour { get; set; }
        public TrafficLighter(List<Bulb> bulbs)
        {
            Bulbs = bulbs;
        }

        public void NextState()
        {
            Behaviour.NextState();
        }
        
    }
}
