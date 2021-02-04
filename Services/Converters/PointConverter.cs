using System.Collections.Generic;
using System.Linq;
using SmallWorld.Service.Dtos;
using SmallWorld.Service.Services.Models;

namespace SmallWorld.Service.Services.Converters
{
    public class PointConverter
    {
        public List<Point> ConvertFromPointInputDto(List<PointInputDto> points)
        {
            return points.Select(x => new Point()
            {
                Id = x.Id,
                XCoordinate = x.XCoordinate,
                YCoordinate = x.YCoordinate
            }).ToList();
        }

        public List<PointOutputDto> ConvertToPointOutputDto(List<Point> points)
        {
            return points.Select(x => new PointOutputDto()
            {
                PointId = x.Id,
                ClosestPoints = x.PointDistances.OrderBy(y => y.Value).Take(3).Select(y => y.Key).ToArray()
            }).ToList();
        }
    }
}
