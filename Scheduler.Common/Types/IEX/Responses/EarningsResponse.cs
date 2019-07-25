using System.Collections.Generic;
using Newtonsoft.Json;

namespace Scheduler.Common.Types
{
    public class EarningsResponse
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("earnings")]
        public IEnumerable<Earning> Earnings { get; set; }
    }
}