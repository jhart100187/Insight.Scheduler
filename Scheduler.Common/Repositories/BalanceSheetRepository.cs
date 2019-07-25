using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Scheduler.Common.Configuration;
using Scheduler.Common.Extensions;
using Scheduler.Common.Errors;
using Scheduler.Common.Types;

namespace Scheduler.Common.Repository
{
    public class BalanceSheetRepository : BaseRepository, IRepository
    {
        public BalanceSheetRepository(IRepositoryConfiguration config,
            ILogger<IRepository> logger) :base(config, logger) { }

        public async Task<int> Insert(IPersistable data)
        {
            data = data ?? throw new ArgumentNullException(nameof(data));
            
            var obj = data.CastToIEXType<BalanceSheet>(Logger);

            var parameters = new SqlParameter[]
            {
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_REPORT_DATE, obj?.ReportDate, SqlDbType.DateTimeOffset, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_CURRENT_CASH, obj?.CurrentCash, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_SHORT_TERM_INVESTMENTS, obj?.ShortTermInvestments, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_RECEIVABLES, obj?.Receivables, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_INVENTORY, obj?.Inventory, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_OTHER_CURRENT_ASSETS, obj?.OtherCurrentAssets, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_CURRENT_ASSETS, obj?.CurrentAssets, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_LONG_TERM_INVESTMENTS, obj?.LongTermInvestments, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_PROPERTY_PLANT_EQUIPMENT, obj?.PropertyPlantEquipment, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_GOODWILL, obj?.Goodwill, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_INTANGIBLE_ASSETS, obj?.IntangibleAssets, SqlDbType.Variant, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_OTHER_ASSETS, obj?.OtherAssets, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_TOTAL_ASSETS, obj?.TotalAssets, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_ACCOUNTS_PAYABLE, obj?.AccountsPayable, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_CURRENT_LONG_TERM_DEBT, obj?.CurrentLongTermDebt, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_OTHER_CURRENT_LIABILITIES, obj?.OtherCurrentLiabilities, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_TOTAL_CURRENT_LIABILITIES, obj?.TotalCurrentLiabilities, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_LONG_TERM_DEBT, obj?.LongTermDebt, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_OTHER_LIABILITIES, obj?.OtherLiabilities, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_MINORITY_INTEREST, obj?.MinorityInterest, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_TOTAL_LIABILITIES, obj?.TotalLiabilities, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_COMMON_STOCK, obj?.CommonStock, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_RETAINED_EARNINGS, obj?.RetainedEarnings, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_TREASURY_STOCK, obj?.TreasuryStock, SqlDbType.Variant, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_CAPITAL_SURPLUS, obj?.CapitalSurplus, SqlDbType.Variant, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_SHAREHOLDER_EQUITY, obj?.ShareholderEquity, SqlDbType.BigInt, ParameterDirection.Input),
                CreateSqlParameter(RepositoryConstants.BALANCE_SHEET_NET_TANGIBLE_ASSETS, obj?.NetTangibleAssets, SqlDbType.BigInt, ParameterDirection.Input)
            };

            var result = 0;

            result = await ExecuteNonQueryAsync(RepositoryConstants.SP_BALANCE_SHEET_INSERT, parameters);

            return result;
        }
    }
}