using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using Quartz.Impl;
using Scheduler.Common.Configuration;
using Scheduler.Jobs;

namespace Scheduler.Main.SchedulingServices
{
    public class ApplicationScheduler : IApplicationScheduler
    {
        private IQuartzConfiguration _config { get; }

        private ILogger<IApplicationScheduler> _logger { get; }

        private IServiceProvider _serviceProvider { get; }

        private StdSchedulerFactory _schedulerFactory { get; }

        private IScheduler _scheduler { get; set; }

        private IJobFactory _jobFactory { get; set; }
        
        public ApplicationScheduler(IServiceProvider serviceProvider,
            IQuartzConfiguration config,
            ILogger<IApplicationScheduler> logger)
        {
            serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            config = config ?? throw new ArgumentNullException(nameof(config));

            logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _serviceProvider = serviceProvider;

            _config = config;

            _schedulerFactory = _CreateSchedulerFactory();
        }

        public async void Start()
        {
            if (_scheduler != null)
                throw new InvalidOperationException("Scheduler already started!");

            _scheduler = _schedulerFactory.GetScheduler().Result;

            foreach (var scheduledJob in _GetScheduledJobServices())
                CreateAndScheduleJob(scheduledJob);

            await _scheduler.Start();
        }

        public void CreateAndScheduleJob<T>(T job) where T: IScheduledJob
        {
            var jobDetail = JobBuilder.Create(job.GetType())
                .WithIdentity(job.JobName, job.JobGroup)
                .Build();

            var jobTrigger = TriggerBuilder.Create()
                .WithIdentity(job.TriggerName, job.TriggerGroup)
                .StartNow()
                .WithSimpleSchedule(scheduleBuilder => scheduleBuilder
                .WithIntervalInSeconds(job.IntervalSeconds)
                .RepeatForever())
                .Build();
            
            ScheduleJob(jobDetail, jobTrigger);
        }

        public async void ScheduleJob(IJobDetail job, ITrigger trigger)
            => await _scheduler.ScheduleJob(job, trigger);

        public void Stop()
        {
            if (_scheduler == null)
                return;

            _scheduler.Shutdown();

            _scheduler = null;
        }

        private IEnumerable<IScheduledJob> _GetScheduledJobServices()
            => _serviceProvider.GetServices<IScheduledJob>();

        private StdSchedulerFactory _CreateSchedulerFactory()
        {
            var properties = new NameValueCollection
            {
                ["quartz.serializer.type"] = _config.SERIALIZER_TYPE,
                ["quartz.jobStore.type"] = _config.JOB_STORE_TYPE,
                ["quartz.jobStore.useProperties"] = _config.USE_PROPERTIES,
                ["quartz.jobStore.dataSource"] = _config.DATA_SOURCE,
                ["quartz.jobStore.tablePrefix"] = _config.TABLE_PREFIX,
                ["quartz.jobStore.driverDelegateType"] = _config.DRIVER_DELEGATE_TYPE,
                ["quartz.dataSource.default.provider"] = _config.DEFAULT_PROVIDER,
                ["quartz.dataSource.default.connectionString"] = _config.CONNECTION_STRING
            };

            return new StdSchedulerFactory(properties);
        }
    }
}