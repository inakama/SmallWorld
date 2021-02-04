using System.Collections.Generic;
using NUnit.Framework;
using SmallWorld.Service.Dtos;
using SmallWorld.Service.Services;
using SmallWorld.Service.Services.Converters;

namespace Services.Test
{
    public class SmallWorldServiceTest
    {
        private SmallWorldService smallWorldService;

        [SetUp]
        public void Setup()
        {
            smallWorldService = new SmallWorldService();
        }

        [Test]
        public void When_ThereAreNoPoints_Expect_NoResults()
        {
            List<PointInputDto> inputPoints = new List<PointInputDto>();

            var closestPoints = smallWorldService.GetClosestPoints(inputPoints);

            Assert.AreEqual(closestPoints.Count, 0);
        }

        [Test]
        public void When_ThereIsOnlyOnePoint_Expect_NoResults()
        {
            List<PointInputDto> inputPoints = new List<PointInputDto>() { new PointInputDto() {  Id=1, XCoordinate = 0, YCoordinate = 0} };

            var closestPoints = smallWorldService.GetClosestPoints(inputPoints);

            Assert.AreEqual(closestPoints[0].ClosestPoints.Length, 0);
        }

        [Test]
        public void When_ThereAreOnlyTwoPoint_Expect_EachPointHasTheOtherone()
        {
            List<PointInputDto> inputPoints = new List<PointInputDto>() 
            { 
                new PointInputDto() { Id = 1, XCoordinate = 0, YCoordinate = 0 },
                new PointInputDto() { Id = 2, XCoordinate = 1, YCoordinate = 1 }
            };

            var closestPoints = smallWorldService.GetClosestPoints(inputPoints);

            Assert.AreEqual(closestPoints.Count, 2);

            Assert.AreEqual(closestPoints[0].ClosestPoints.Length, 1);
            Assert.AreEqual(closestPoints[0].ClosestPoints[0], 2);
            Assert.AreEqual(closestPoints[1].ClosestPoints.Length, 1);
            Assert.AreEqual(closestPoints[1].ClosestPoints[0], 1);
        }

        [Test]
        public void When_ThereAreOnlyFourPoints_Expect_AllPointHasTheOThersPoints()
        {
            List<PointInputDto> inputPoints = new List<PointInputDto>() 
            { 
                   new PointInputDto() { Id = 1, XCoordinate = 0, YCoordinate = 0 },
                   new PointInputDto() { Id = 2, XCoordinate = 1, YCoordinate = 1 },
                   new PointInputDto() { Id = 3, XCoordinate = 2, YCoordinate = 2 },
                   new PointInputDto() { Id = 4, XCoordinate = 3, YCoordinate = 3 }
            };

            var closestPoints = smallWorldService.GetClosestPoints(inputPoints);

            Assert.AreEqual(closestPoints.Count, 4);

            foreach (var point in closestPoints)
            {
                Assert.AreEqual(point.ClosestPoints.Length, 3);
            }
        }

        [Test]
        public void When_PointOneThreeAndTwoAreTheClosestFromPointFourInThatOrder_Expect_ThosePointsAreIncludedInTheSameOrder()
        {
            List<PointInputDto> inputPoints = new List<PointInputDto>()
            {
                   new PointInputDto() { Id = 1, XCoordinate = 1, YCoordinate = 1 },
                   new PointInputDto() { Id = 2, XCoordinate = 3, YCoordinate = 3 },
                   new PointInputDto() { Id = 3, XCoordinate = 2, YCoordinate = 2 },
                   new PointInputDto() { Id = 4, XCoordinate = 0, YCoordinate = 0 },
                   new PointInputDto() { Id = 5, XCoordinate = 4, YCoordinate = 4 }
            };

            var closestPoints = smallWorldService.GetClosestPoints(inputPoints);
            var pointFour = closestPoints.Find(x => x.PointId == 4);

            Assert.AreEqual(pointFour.ClosestPoints.Length, 3);
            Assert.AreEqual(pointFour.ClosestPoints[0], 1);
            Assert.AreEqual(pointFour.ClosestPoints[1], 3);
            Assert.AreEqual(pointFour.ClosestPoints[2], 2);
        }
    }
}