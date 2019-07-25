using System;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Common.Configuration;
using Scheduler.Jobs;
using Scheduler.Common.Repository;
using Scheduler.Main.SchedulingServices;
using Serilog;
using System.Collections.Generic;

namespace Scheduler.Main.IoC
{
    public class ApplicationContainer : IApplicationContainer
    {
        public IServiceCollection Collection { get; private set; }

        public IServiceScope Scope { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public ApplicationContainer() => Collection = new ServiceCollection();

        public void RegisterJobServices() => Collection.AddTransient<IScheduledJob, AAPLJob>();

        public void RegisterSchedulingService() => Collection.AddTransient<IApplicationScheduler, ApplicationScheduler>();

        public void Dispose() => Scope.Dispose();

        public static IApplicationContainer CreateDefaultContainer()
            => new ApplicationContainer().ConfigureLogging().RegisterAllServices().BuildServiceProvider().CreateScope();

        public static IApplicationContainer CreateDefaultTestContainer()
            => new ApplicationContainer().ConfigureLogging().RegisterAllServices();

        public T GetService<T>()
            => Scope != null ? Scope.ServiceProvider.GetService<T>() : default(T);

        public IEnumerable<T> GetServices<T>()
            => Scope?.ServiceProvider.GetServices<T>();

        public IApplicationContainer BuildServiceProvider()
        {
            ServiceProvider = Collection?.BuildServiceProvider();
            return this;
        }

        public IApplicationContainer CreateScope()
        {
            Scope = ServiceProvider?.CreateScope();
            return this;
        }

        public void RegisterConfigurationServices()
        {
            Collection.AddTransient<IQuartzConfiguration, QuartzConfiguration>( _ => new QuartzConfiguration(ConfigurationFactory.QUARTZ_CONFIG));
            Collection.AddTransient<IIEXConfiguration, IEXConfiguration>(_ => new IEXConfiguration(ConfigurationFactory.IEX_CONFIG));
            Collection.AddTransient<IRepositoryConfiguration, RepositoryConfiguration>(_ => new RepositoryConfiguration(ConfigurationFactory.REPOSITORY_CONFIG));
        }

        public void RegisterRepositoryServices()
        {
            Collection.AddTransient<IRepository, BalanceSheetRepository>();
            Collection.AddTransient<IRepository, EarningRepository>();
        }

        public IApplicationContainer RegisterAllServices()
        {
            RegisterConfigurationServices();
            RegisterJobServices();
            RegisterRepositoryServices();
            RegisterSchedulingService();
            return this;
        }

        public IApplicationContainer ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("../../Scheduler.log",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            Collection.AddLogging(configure => configure.AddSerilog());

            return this;
        }
    }
}