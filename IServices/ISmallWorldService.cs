using System.Collections.Generic;
using SmallWorld.Service.Dtos;

namespace SmallWorld.Service.IServices
{
    public interface ISmallWorldService
    {
        List<PointOutputDto> GetClosestPoints(List<PointInputDto> points);
    }
}
