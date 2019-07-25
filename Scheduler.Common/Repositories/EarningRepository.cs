using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Scheduler.Common.Configuration;
using Scheduler.Common.Extensions;
using Scheduler.Common.Errors;
using Scheduler.Common.Types;

namespace Scheduler.Common.Repository
{
    public class EarningRepository : BaseRepository, IRepository
    {
        public EarningRepository(IRepositoryConfiguration config,
            ILogger<IRepository> logger) :base(config, logger) { }

        public async Task<int> Insert(IPersistable data)
        {
            data = data ?? throw new ArgumentNullException(nameof(data));
            
            var obj = data.CastToIEXType<Earning>(Logger);

            var parameters = new SqlParameter[]
            {
                CreateSqlParameter(RepositoryConstants.EARNING_ACTUAL_EPS, obj?.ActualEps, SqlDbType.Float, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_CONSENSUS_EPS, obj?.ConsensusEps, SqlDbType.Float, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_ANNOUNCE_TIME, obj?.AnnounceTime, SqlDbType.VarChar, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_NUMBER_OF_ESTIMATES, obj?.NumberOfEstimates, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_EPS_SURPRISE_DOLLAR, obj?.EpsSurpriseDollar, SqlDbType.Float, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_EPS_REPORT_DATE, obj?.EpsReportDate, SqlDbType.DateTimeOffset, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_FISCAL_PERIOD, obj?.FiscalPeriod, SqlDbType.VarChar, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_FISCAL_END_DATE, obj?.FiscalEndDate, SqlDbType.DateTimeOffset, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_YEAR_AGO, obj?.YearAgo, SqlDbType.Float, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.EARNING_YEAR_AGO_CHANGE_PERCENT, obj?.YearAgoChangePercent, SqlDbType.Float, ParameterDirection.Input)
            };

            int result = 0;

            result = await ExecuteNonQueryAsync(RepositoryConstants.SP_EARNING_INSERT, parameters);

            return result;
        }
    }
}