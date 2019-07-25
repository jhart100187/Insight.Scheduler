using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Xunit;
using Scheduler.Tests.Fixtures;
using Scheduler.Main.SchedulingServices;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Jobs;
using Scheduler.Tests.Mocks;
using Quartz;

namespace Scheduler.Tests.Tests
{
    public class JobTest : IClassFixture<ApplicationContainerFixture>
    {
        private readonly ApplicationContainerFixture _appContainerFixture;

        public JobTest(ApplicationContainerFixture appContainerFixture)
            => _appContainerFixture = appContainerFixture;

        /// <summary>
        /// Description: Simple test to verify that the IScheduled.Execute method is being called
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExecuteShouldBeCalled()
        {
            var job = _appContainerFixture.Container.GetServices<IScheduledJob>()
                .Where(scheduledJob => scheduledJob.GetType() == typeof(MockScheduledJob)).FirstOrDefault();

            var context = _appContainerFixture.Container.GetService<IJobExecutionContext>();

            await Assert.ThrowsAsync<NotImplementedException>(async () => await job.Execute(context));
        }
    }
}
