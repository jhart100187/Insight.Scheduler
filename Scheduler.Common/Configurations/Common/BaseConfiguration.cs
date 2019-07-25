using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Scheduler.Common.Configuration
{
    public class BaseConfiguration
    {
        private IConfiguration _configuration { get; }

        public BaseConfiguration(IConfiguration configuration)
            => _configuration = configuration;

        protected string GetValue(params string[] sections)
            => sections.Count() == 0 ? null : _configuration[_GetKey(sections)];

        private string _GetKey(params string[] sections)
            => sections != null ? string.Join(":", sections) : null;
    }
}