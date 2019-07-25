using Quartz;

namespace Scheduler.Jobs
{
    public interface IScheduledJob : IJob
    {
        string JobName { get; }

        string JobGroup { get; }

        string TriggerName { get; }

        string TriggerGroup { get; }

        int IntervalSeconds { get; }
    }
}