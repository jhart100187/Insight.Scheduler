using Scheduler.Main.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Jobs;
using Scheduler.Tests.Mocks;
using Quartz;

namespace Scheduler.Tests.Fixtures
{
    public class ApplicationContainerFixture : BaseFixture
    {
        public IApplicationContainer Container { get; private set; }

        public ApplicationContainerFixture() => _InitializeContainer();

        private void _InitializeContainer()
        {
            Container = Container == null ?
                ApplicationContainer.CreateDefaultTestContainer() : throw new Exception("Container already created!");
            _RegisterMockServices();
            _BuildServiceProviderAndCreateScope();
        }

        private void _BuildServiceProviderAndCreateScope()
            => Container?.BuildServiceProvider()?.CreateScope();

        private void _RegisterMockServices()
        {
            if (Container != null)
            {
                Container.Collection.AddTransient<IScheduledJob, MockScheduledJob>();
                Container.Collection.AddTransient<IJobExecutionContext, MockJobExecutionContext>();
            }
        }

        ~ApplicationContainerFixture() => Container.Dispose();
    }
}
