using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Quartz;
using Microsoft.Extensions.Logging;
using Scheduler.Common.Types;
using Scheduler.Common.Configuration;
using Scheduler.Common.Repository;
using Scheduler.Common.Extensions;

namespace Scheduler.Jobs
{
    public class AAPLJob : BaseJob, IScheduledJob
    {
        private IEnumerable<IRepository> _repos { get; }

        private string _stockSymbol => "aapl";

        public string JobName => "AAPJob";

        public string TriggerName => "AAPLTrigger";

        public int IntervalSeconds => 12;

        public string JobGroup { get; }

        public string TriggerGroup { get; }

        public AAPLJob(IIEXConfiguration config,
            IEnumerable<IRepository> repos,
            ILogger<IScheduledJob> logger) 
            :base(config, logger)
        {
            config = config ?? throw new ArgumentNullException(nameof(config));

            logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _repos = repos ?? throw new ArgumentNullException(nameof(repos));

            JobGroup = GenerateGroup();

            TriggerGroup = GenerateGroup();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var balanceSheetsResponse = await ExecuteAsync<BalanceSheetsResponse>
                (CreateResource(IEXArea.STOCK, _stockSymbol, IEXPath.BALANCE_SHEET));

            var earningsResponse = await ExecuteAsync<EarningsResponse>
                (CreateResource(IEXArea.STOCK, _stockSymbol, IEXPath.EARNINGS));

            foreach (var balanceSheet in balanceSheetsResponse.BalanceSheets)
                await _InsertData<BalanceSheetRepository>(balanceSheet);

            foreach (var earning in earningsResponse.Earnings)
                await _InsertData<EarningRepository>(earning);
        }

        private async Task<int> _InsertData<T>(IPersistable data) where T : IRepository
            => await _repos.GetRepository<T>().Insert(data);
    }
}