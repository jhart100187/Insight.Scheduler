using System;

namespace Scheduler.Common.Configuration
{
    public interface IQuartzConfiguration
    {
        string SERIALIZER_TYPE { get; }

        string JOB_STORE_TYPE { get; }

        string USE_PROPERTIES { get; }

        string DATA_SOURCE { get; }

        string TABLE_PREFIX { get; }

        string DRIVER_DELEGATE_TYPE { get; }

        string DEFAULT_PROVIDER { get; }

        string CONNECTION_STRING { get; }
    }
}