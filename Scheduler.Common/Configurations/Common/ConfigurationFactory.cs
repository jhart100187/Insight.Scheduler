using System.IO;
using Microsoft.Extensions.Configuration;

namespace Scheduler.Common.Configuration
{
    public class ConfigurationFactory
    {
        private static IConfiguration _APP_CONFIG => new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath("../../../../."))
                .AddJsonFile("appsettings.json")
                .Build();

        public static IConfiguration QUARTZ_CONFIG => _APP_CONFIG?.GetSection("quartz");

        public static IConfiguration IEX_CONFIG => _APP_CONFIG?.GetSection("iex");

        public static IConfiguration REPOSITORY_CONFIG => _APP_CONFIG?.GetSection("repository");
    }
}