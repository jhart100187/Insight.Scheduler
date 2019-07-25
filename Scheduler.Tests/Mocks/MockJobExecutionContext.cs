using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Quartz;

namespace Scheduler.Tests.Mocks
{
    public class MockJobExecutionContext : IJobExecutionContext
    {
        public IScheduler Scheduler => throw new NotImplementedException();
  
        public ITrigger Trigger => throw new NotImplementedException();

        public ICalendar Calendar => throw new NotImplementedException();

        public bool Recovering => throw new NotImplementedException();

        public TriggerKey RecoveringTriggerKey => throw new NotImplementedException();

        public int RefireCount => throw new NotImplementedException();

        public JobDataMap MergedJobDataMap => throw new NotImplementedException();

        public IJobDetail JobDetail => throw new NotImplementedException();

        public IJob JobInstance => throw new NotImplementedException();

        public DateTimeOffset FireTimeUtc => throw new NotImplementedException();

        public DateTimeOffset? ScheduledFireTimeUtc => throw new NotImplementedException();

        public DateTimeOffset? PreviousFireTimeUtc => throw new NotImplementedException();

        public DateTimeOffset? NextFireTimeUtc => throw new NotImplementedException();

        public string FireInstanceId => throw new NotImplementedException();

        public object Result { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TimeSpan JobRunTime => throw new NotImplementedException();

        public CancellationToken CancellationToken => throw new NotImplementedException();

        public object Get(object key)
        {
            throw new NotImplementedException();
        }

        public void Put(object key, object objectValue)
        {
            throw new NotImplementedException();
        }
    }
}
