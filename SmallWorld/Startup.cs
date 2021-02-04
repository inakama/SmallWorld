using System;
using Microsoft.Extensions.DependencyInjection;
using SmallWorld.Service.IServices;
using SmallWorld.Service.Services;
using SmallWorld.Service.Services.Converters;

namespace SmallWorld.ConsoleApp
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<ISmallWorldService, SmallWorldService>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
