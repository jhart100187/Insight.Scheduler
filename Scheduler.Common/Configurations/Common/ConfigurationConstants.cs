using System;

namespace Scheduler.Common.Configuration
{
    public class ConfigurationConstants
    {
        #region IEX
        public static string IEX => "iex";

        public static string HOST => "host";

        public static string VERSION => "version";

        public static string TOKEN => "token";
        #endregion

        #region Quartz
        public static string QUARTZ => "quartz";

        public static string SERIALIZER_TYPE => "serializerType";

        public static string JOB_STORE_TYPE => "jobStoreType";

        public static string USE_PROPERTIES => "useProperties";

        public static string DATA_SOURCE => "dataSource";

        public static string TABLE_PREFIX => "tablePrefix";

        public static string DRIVER_DELEGATE_TYPE => "driverDelegateType";

        public static string DEFAULT_PROVIDER => "defaultProvider";

        public static string QUARTZ_CONNECTION_STRING => "quartzConnectionString";
        #endregion

        #region Repository
        public static string SQL_CONNECTION_STRING => "sqlConnectionString";
        #endregion
    }
}