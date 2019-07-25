using Microsoft.Extensions.Configuration;

namespace Scheduler.Common.Configuration
{
    public class RepositoryConfiguration : BaseConfiguration, IRepositoryConfiguration
    {
        public RepositoryConfiguration(IConfiguration config) :base(config) { }

        public string SQL_CONNECTION_STRING => GetValue(ConfigurationConstants.SQL_CONNECTION_STRING);
    }
}