using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.Service.Services.Models
{
    public class Point
    {
        public int Id { get; set; }

        public double XCoordinate { get; set; }

        public double YCoordinate { get; set; }

        public Dictionary<int, double> PointDistances { get; set; } = new Dictionary<int, double>();

        public double CalculateDistanceFrom( Point anotherPoint)
        {
            return Math.Sqrt((Math.Pow((this.XCoordinate - anotherPoint.XCoordinate), 2) +
                     Math.Pow((this.YCoordinate - anotherPoint.YCoordinate), 2)));
        }
    }
}
