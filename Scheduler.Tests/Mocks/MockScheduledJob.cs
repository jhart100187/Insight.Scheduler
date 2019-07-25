using Quartz;
using Scheduler.Jobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Tests.Mocks
{
    public class MockScheduledJob : IScheduledJob
    {
        public string JobName => "MockJob";

        public string JobGroup => "MockJobGroup";

        public string TriggerName => "MockTrigger";

        public string TriggerGroup => "MockTriggerGroup";

        public int IntervalSeconds => 12;

        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
