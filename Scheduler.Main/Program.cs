using System;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Main.SchedulingServices;
using Scheduler.Main.IoC;

namespace Scheduler.Main
{
    public class Program
    {
        private static IApplicationContainer _appServiceContainer { get; set; }

        public static void Main(string[] args)
        {
            _InitializeApplication();

            _StartApplication();
        }

        private static void _InitializeApplication()
        {
            _appServiceContainer = _appServiceContainer == null ? 
                ApplicationContainer.CreateDefaultContainer() : throw new Exception("ApplicationContainer already initialized!");

            _appServiceContainer.ConfigureLogging().RegisterAllServices();
        }
        private static void _StartApplication()
        {
            _appServiceContainer = _appServiceContainer ??
                throw new Exception("AppServiceContainer is not built!");

            _appServiceContainer.BuildServiceProvider().CreateScope();

            _appServiceContainer.Scope?.ServiceProvider?
                .GetService<IApplicationScheduler>().Start();
        }
    }
}
