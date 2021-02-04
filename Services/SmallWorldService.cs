using System.Collections.Generic;
using SmallWorld.Service.Dtos;
using SmallWorld.Service.IServices;
using SmallWorld.Service.Services.Converters;

namespace SmallWorld.Service.Services
{
    public class SmallWorldService : ISmallWorldService
    {

        private readonly PointConverter converter;

        public SmallWorldService()
        {
            this.converter = new PointConverter();
        }

        public List<PointOutputDto> GetClosestPoints(List<PointInputDto> inputPoints)
        {
            var points = this.converter.ConvertFromPointInputDto(inputPoints);

            foreach (var point in points)
            {
                foreach (var anotherPoint in points)
                {
                    if (point.Id != anotherPoint.Id)
                    {
                        var distance = point.CalculateDistanceFrom(anotherPoint);
                        point.PointDistances.Add(anotherPoint.Id, distance);
                    }
                }
            }

            return this.converter.ConvertToPointOutputDto(points);
        }
    }
}
