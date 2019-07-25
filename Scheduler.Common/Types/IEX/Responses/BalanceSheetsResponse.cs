using System.Collections.Generic;
using Newtonsoft.Json;

namespace Scheduler.Common.Types
{
    public class BalanceSheetsResponse
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("balancesheet")]
        public IEnumerable<BalanceSheet> BalanceSheets { get; set; }
    }
}