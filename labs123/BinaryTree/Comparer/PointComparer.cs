using System;
using System.Collections.Generic;
using System.Text;
using Substance;

namespace Comparer
{
    public class PointComparer : Comparer<Point>
    {
        private double calculateLength(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - 0, 2) + Math.Pow(point.Y - 0, 2));
        }
        public override int Compare(Point firstPoint, Point secondPoint)
        {
            int result = 0;

            if (calculateLength(firstPoint) > calculateLength(secondPoint))
            {
                result = 1;
            }
            else if (calculateLength(firstPoint) < calculateLength(secondPoint))
            {
                result = -1;
            }

            return result;
        }
    }
}
