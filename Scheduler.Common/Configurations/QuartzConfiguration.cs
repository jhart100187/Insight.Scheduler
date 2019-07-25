using Microsoft.Extensions.Configuration;

namespace Scheduler.Common.Configuration
{
    public class QuartzConfiguration : BaseConfiguration, IQuartzConfiguration
    {
        public QuartzConfiguration(IConfiguration config) :base(config) { }

        public string SERIALIZER_TYPE => GetValue(ConfigurationConstants.SERIALIZER_TYPE);

        public string JOB_STORE_TYPE => GetValue(ConfigurationConstants.JOB_STORE_TYPE);

        public string USE_PROPERTIES => GetValue(ConfigurationConstants.USE_PROPERTIES);

        public string DATA_SOURCE => GetValue(ConfigurationConstants.DATA_SOURCE);

        public string TABLE_PREFIX => GetValue(ConfigurationConstants.TABLE_PREFIX);

        public string DRIVER_DELEGATE_TYPE => GetValue(ConfigurationConstants.DRIVER_DELEGATE_TYPE);

        public string DEFAULT_PROVIDER => GetValue(ConfigurationConstants.DEFAULT_PROVIDER);

        public string CONNECTION_STRING => GetValue(ConfigurationConstants.QUARTZ_CONNECTION_STRING);
    }
}