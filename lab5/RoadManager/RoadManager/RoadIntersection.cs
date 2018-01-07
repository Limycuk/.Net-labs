using Behaviours;
using System;
using System.Collections.Generic;
using System.Timers;

namespace RoadManager
{
    public class RoadIntersection
    {
        BehaviourFactory behaviourFactory = new BehaviourFactory();
        List<TrafficLighter> trafficLighters { get; set; } = new List<TrafficLighter>();
        Timer Timer { get; set; }
        public Type Behahav
        {
            set
            {
                Object tehav = Activator.CreateInstance(value);

            }
        }
        public void Subscribe(TrafficLighter trafficLighter, string behaviourType, int startPosition)
        {
            trafficLighter.Behaviour = behaviourFactory.CreateBehaviour(behaviourType, startPosition, trafficLighter.Bulbs);
            trafficLighters.Add(trafficLighter);
        }

        public void ChangeBehaviour(string behaviourType)
        {
            int i = 0;
            foreach(TrafficLighter trafficLighter in trafficLighters)
            {
                trafficLighter.Behaviour = behaviourFactory.CreateBehaviour(behaviourType, i++, trafficLighter.Bulbs);
            }
        }
        public void Start()
        {
            NextState();
        }

        public void Start(int miliseconds)
        {
            Timer = new Timer(miliseconds);
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            NextState();
        }

        void NextState ()
        {
            foreach (TrafficLighter trafficLighter in trafficLighters)
            {
                trafficLighter.NextState();
            }
        }
    }
}
