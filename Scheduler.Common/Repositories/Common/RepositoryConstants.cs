using System;

namespace Scheduler.Common.Repository
{
    public class RepositoryConstants
    {
        #region BalanceSheet
        public static string SP_BALANCE_SHEET_INSERT => "[company].[InsertBalanceSheet]";

        public static string BALANCE_SHEET_REPORT_DATE => "ReportDate";

        public static string BALANCE_SHEET_CURRENT_CASH => "CurrentCash";

        public static string BALANCE_SHEET_SHORT_TERM_INVESTMENTS => "ShortTermInvestments";

        public static string BALANCE_SHEET_RECEIVABLES => "Receivables";

        public static string BALANCE_SHEET_INVENTORY => "Inventory";

        public static string BALANCE_SHEET_OTHER_CURRENT_ASSETS => "OtherCurrentAssets";

        public static string BALANCE_SHEET_CURRENT_ASSETS => "CurrentAssets";

        public static string BALANCE_SHEET_LONG_TERM_INVESTMENTS => "LongTermInvestments";

        public static string BALANCE_SHEET_PROPERTY_PLANT_EQUIPMENT => "PropertyPlantEquipment";

        public static string BALANCE_SHEET_GOODWILL => "Goodwill";

        public static string BALANCE_SHEET_INTANGIBLE_ASSETS => "IntangibleAssets";

        public static string BALANCE_SHEET_OTHER_ASSETS => "OtherAssets";

        public static string BALANCE_SHEET_TOTAL_ASSETS => "TotalAssets";

        public static string BALANCE_SHEET_ACCOUNTS_PAYABLE => "AccountsPayable";

        public static string BALANCE_SHEET_CURRENT_LONG_TERM_DEBT => "CurrentLongTermDebt";

        public static string BALANCE_SHEET_OTHER_CURRENT_LIABILITIES => "OtherCurrentLiabilities";

        public static string BALANCE_SHEET_TOTAL_CURRENT_LIABILITIES => "TotalCurrentLiabilities";

        public static string BALANCE_SHEET_LONG_TERM_DEBT => "LongTermDebt";

        public static string BALANCE_SHEET_OTHER_LIABILITIES => "OtherLiabilities";

        public static string BALANCE_SHEET_MINORITY_INTEREST => "MinorityInterest";

        public static string BALANCE_SHEET_TOTAL_LIABILITIES => "TotalLiabilities";

        public static string BALANCE_SHEET_COMMON_STOCK => "CommonStock";

        public static string BALANCE_SHEET_RETAINED_EARNINGS => "RetainedEarnings";

        public static string BALANCE_SHEET_TREASURY_STOCK => "TreasuryStock";

        public static string BALANCE_SHEET_CAPITAL_SURPLUS => "CapitalSurplus";

        public static string BALANCE_SHEET_SHAREHOLDER_EQUITY => "ShareholderEquity";

        public static string BALANCE_SHEET_NET_TANGIBLE_ASSETS => "NetTangibleAssets";
        #endregion

        #region Earning
        public static string SP_EARNING_INSERT => "[company].[InsertEarning]";

        public static string EARNING_ACTUAL_EPS => "ActualEPS";

        public static string EARNING_CONSENSUS_EPS => "ConsensusEPS";

        public static string EARNING_ANNOUNCE_TIME => "AnnounceTime";

        public static string EARNING_NUMBER_OF_ESTIMATES => "NumberOfEstimates";

        public static string EARNING_EPS_SURPRISE_DOLLAR => "EPSSurpriseDollar";

        public static string EARNING_EPS_REPORT_DATE => "EPSReportDate";

        public static string EARNING_FISCAL_PERIOD => "FiscalPeriod";

        public static string EARNING_FISCAL_END_DATE => "FiscalEndDate";

        public static string EARNING_YEAR_AGO => "YearAgo";

        public static string EARNING_YEAR_AGO_CHANGE_PERCENT => "YearAgoChangePercent";
        #endregion
    }
}