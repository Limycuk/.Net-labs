using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Behaviours;
using Bulbs;
using RoadManager;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bulb> firstBulbs = new List<Bulb>()
            {
                new GreenBulb(),
                new OrangeBulb(),
                new GreenBulb(),
            };
            TrafficLighter firstTrafficLighter = new TrafficLighter(firstBulbs);

            List<Bulb> secondBulbs = new List<Bulb>()
            {
                new GreenBulb(),
                new OrangeBulb(),
                new GreenBulb(),
            };
            TrafficLighter secondTrafficLighter = new TrafficLighter(secondBulbs);

            RoadIntersection roadIntersection = new RoadIntersection();

            roadIntersection.Subscribe(firstTrafficLighter, "daily", 0);
            roadIntersection.Subscribe(secondTrafficLighter, "daily", 1);
            roadIntersection.Start(30000);

            roadIntersection.ChangeBehaviour("orangePulse");
            roadIntersection.Start();
        }
    }
}
