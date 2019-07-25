using System;

namespace Scheduler.Common.Configuration
{
    public interface IRepositoryConfiguration
    {
        string SQL_CONNECTION_STRING { get; }
    }
}