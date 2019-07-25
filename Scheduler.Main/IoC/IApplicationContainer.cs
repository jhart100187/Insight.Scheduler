using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduler.Main.IoC
{
    public interface IApplicationContainer: IDisposable
    {
        IServiceProvider ServiceProvider { get; }

        IServiceScope Scope { get; }

        IServiceCollection Collection { get; }

        IApplicationContainer BuildServiceProvider();

        IApplicationContainer CreateScope();

        T GetService<T>();

        IEnumerable<T> GetServices<T>();

        void RegisterConfigurationServices();

        void RegisterJobServices();

        void RegisterRepositoryServices();

        void RegisterSchedulingService();

        IApplicationContainer RegisterAllServices();

        IApplicationContainer ConfigureLogging();
    }
}