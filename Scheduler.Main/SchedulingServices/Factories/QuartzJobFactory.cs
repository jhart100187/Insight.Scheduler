using System;
using Quartz;
using Quartz.Spi;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Jobs;

namespace Scheduler.Main.SchedulingServices
{
    //Note: If using this file, must add _scheduler.JobFactory = new QuartzJobFactory(_serviceProvider);
    //to Start() method of Quartz type

    public class QuartzJobFactory : IJobFactory
    {
        private IServiceProvider _serviceProvider { get; }

        public QuartzJobFactory(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
            => _serviceProvider.GetService<IScheduledJob>();

        public void ReturnJob(IJob job) => job = null;
    }
}