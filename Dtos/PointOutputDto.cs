namespace SmallWorld.Service.Dtos
{
    public class PointOutputDto
    {
        public int PointId { get; set; }

        public int[] ClosestPoints { get; set; }
    }
}
