using Microsoft.Extensions.Configuration;

namespace Scheduler.Common.Configuration
{
    public class IEXConfiguration : BaseConfiguration, IIEXConfiguration
    {
        public IEXConfiguration(IConfiguration config) :base(config) { }

        public string HOST => GetValue(ConfigurationConstants.HOST);

        public string VERSION => GetValue(ConfigurationConstants.VERSION);

        public string TOKEN => GetValue(ConfigurationConstants.TOKEN);
    }
}