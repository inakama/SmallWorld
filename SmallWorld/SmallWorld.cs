using System;
using System.Collections.Generic;
using System.Configuration;
using SmallWorld.Service.Dtos;
using SmallWorld.Service.IServices;
using SmallWorld.Service.Services;

namespace SmallWorld
{
    public class SmallWorld
    {
        private readonly CSVManager csvManager;
        private readonly ISmallWorldService smallWorldService;

        public SmallWorld()
        {
            this.csvManager = new CSVManager();
            this.smallWorldService = new SmallWorldService();
        }

        public void Start()
        {
            var inputPoints = this.csvManager.GetPoints(ConfigurationManager.AppSettings["CSVFile"]);
            var closestPoints = smallWorldService.GetClosestPoints(inputPoints);
            ShowToConsole(closestPoints);
        }

        private void ShowToConsole(List<PointOutputDto> closestPoints)
        {
            foreach (var point in closestPoints)
            {
                Console.Write(point.PointId + " - ");

                foreach (var closePoint in point.ClosestPoints)
                {
                    Console.Write(closePoint + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
