using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Microsoft.Extensions.DependencyInjection;
using SmallWorld.Service.Dtos;
using SmallWorld.Service.IServices;

namespace SmallWorld.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = Startup.ConfigureService();
            //var smallWorldService = container.GetRequiredService<ISmallWorldService>();

            //new SmallWorld(smallWorldService).Start();

            new SmallWorld().Start();
        }
    }
}
