using System;
using NUnit.Framework;
using SmallWorld.Service.Services.Models;

namespace Services.Test
{
    public class PointTest
    {
        private Point point;

        [SetUp]
        public void Setup()
        {
            this.point = new Point();
        }

        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 0, 1, 1, 1.4142)]
        [TestCase(-1, -1, 1, 1, 2.8284)]
        [TestCase(-1, 1, 1, 1, 2)]
        [TestCase(2, 2, 1, -1, 3.1622)]
        [TestCase(-2, 2, 1, -1, 4.2426)]
        public void When_ThereAreNoPoints_Expect_NoResults(
                                            double xCoordinateFromPoint, 
                                            double yCoordinateFromPoint,
                                            double xCoordinateFromAnotherPoint,
                                            double yCoordinateFromAnotherPoint,
                                            double distance
        )
        {
            this.point.XCoordinate = xCoordinateFromPoint;
            this.point.YCoordinate = yCoordinateFromPoint;

            Point anotherPoint = new Point();
            anotherPoint.XCoordinate = xCoordinateFromAnotherPoint;
            anotherPoint.YCoordinate = yCoordinateFromAnotherPoint;

            var result = this.point.CalculateDistanceFrom(anotherPoint);

            Assert.AreEqual(distance, Math.Truncate(result * 10000) / 10000);
        }



    }
}
