using Quartz;

namespace Scheduler.Main.SchedulingServices
{
    public interface IApplicationScheduler
    {
        void Start();

        void Stop();

        void ScheduleJob(IJobDetail job, ITrigger trigger);
    }
}