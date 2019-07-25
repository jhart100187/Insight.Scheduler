using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Scheduler.Common.Configuration;
using Scheduler.Common.Errors;

namespace Scheduler.Common.Repository
{
    public class BaseRepository
    {
        private string _connectionString { get; }

        protected ILogger<IRepository> Logger { get; }

        protected BaseRepository(IRepositoryConfiguration config, ILogger<IRepository> logger)
        {
            config = config ?? throw new ArgumentNullException(nameof(config));

            logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            Logger = logger;

            _connectionString = config.SQL_CONNECTION_STRING;
        }

        private SqlConnection _CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch(Exception ex)
                {
                    Logger.LogCritical(ex, CommonErrorMessages.UNABLE_TO_OPEN_DB_CONNECTION);
                    throw ex;
                }
            }

            return connection;
        }

        protected SqlCommand CreateCommand(SqlConnection connection, string commandText, CommandType commandType)
            => new SqlCommand(commandText, connection) { CommandType = commandType };

        protected SqlParameter CreateSqlParameter(string name, object value, SqlDbType type, ParameterDirection direction)
            => new SqlParameter() { ParameterName = name, Value = value, SqlDbType = type, Direction = direction };

        protected async Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[] parameters = null,
        CommandType commandType = CommandType.StoredProcedure)
        {
            var returnValue = -1;

            using (var connection = _CreateConnection())
            {
                var command = CreateCommand(connection, procedureName, commandType);

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                try
                {
                    returnValue = await command.ExecuteNonQueryAsync();
                }
                catch(Exception ex)
                {
                    if (ex.GetType() == typeof(DbException))
                        Logger.LogCritical(ex, CommonErrorMessages.UNABLE_TO_EXECUTE_STORED_PROCEDURE);
                    else
                    {
                        Logger.LogCritical(ex, CommonErrorMessages.UNEXPECTED_ERROR_MESSAGE);

                        throw ex;
                    }
                }
            }

            return returnValue;
        }

        protected async Task<SqlDataReader> ExecuteReaderAsyncReturnDataReader(string procedureName,
        SqlParameter[] parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var connection = _CreateConnection();

            var command = CreateCommand(connection, procedureName, commandType);

            if (parameters != null && parameters.Length > 0)
                command.Parameters.AddRange(parameters);

            Task<SqlDataReader> result = null;

            try
            {
                result = command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch(Exception ex)
            {
                Logger.LogCritical(ex, CommonErrorMessages.UNEXPECTED_ERROR_MESSAGE);

                throw ex;
            }

            return await result;
        }
    }
}