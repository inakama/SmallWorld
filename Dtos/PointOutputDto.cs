using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.Service.Dtos
{
    public class PointOutputDto
    {
        public int PointId { get; set; }

        public int[] ClosestPoints { get; set; }
    }
}
