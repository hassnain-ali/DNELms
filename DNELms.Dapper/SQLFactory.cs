using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DNELms.Dapper
{
    public sealed class SQLFactory : ISQLFactory
    {
        #region Ctor

        private readonly IHttpContextAccessor accessor;
        private readonly IDbConnection SqlConnection;
        private readonly ILogger<SQLFactory> logger;
        public SQLFactory(IHttpContextAccessor _accessor, IConfiguration configuration, ILogger<SQLFactory> _logger)
        {
            accessor = _accessor;
            logger = _logger;
            SqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        #endregion

        #region ScopeId
        public (bool, int) ExecuteProcedureGetScopeId(string cmd)
        {
            try
            {
                int id = SqlConnection.QueryFirst<int>(cmd, commandType: CommandType.StoredProcedure);
                return (id > 0, id);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteCommandGetScopeId");
                return (false, 0);
            }
        }
        public (bool, int) ExecuteProcedureGetScopeId(string cmd, DynamicParameters command)
        {
            try
            {
                int id = SqlConnection.QueryFirst<int>(cmd, param: command, commandType: CommandType.StoredProcedure);
                return (id > 0, id);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteProcedureGetScopeId");
                return (false, 0);
            }
        }
        /// <summary>
        /// Returns the scope id of added row
        /// </summary>
        /// <typeparam name="T">Class to add in to</typeparam>
        /// <param name="cmd">procedure name</param>
        /// <param name="obj">model with values</param>
        /// <param name="toSkip">which column to skip from given model</param>
        /// <returns>scope id of newly enterd row</returns>
        public int ExecuteProcedureGetScopeId<T>(string cmd, T obj, string[] toSkip) where T : new()
        {
            try
            {
                DynamicParameters command = new DynamicParameters();
                foreach (PropertyInfo item in typeof(T).GetProperties().Where(s => !s.Name.In(toSkip)))
                {
                    command.Add(("@" + item.Name), obj.GetType().GetProperty(item.Name).GetValue(obj));
                }
                return SqlConnection.QueryFirst<int>(cmd, param: command, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteProcedureGetScopeId<T>");
                return 0;
            }
        }
        public int MultiRows<T>(string cmd, List<T> obj, CommandType commandType = CommandType.StoredProcedure, string[] toSkip = null) where T : new()
        {
            try
            {
                List<DynamicParameters> command = new List<DynamicParameters>();
                foreach (var item1 in obj)
                {
                    var dP = new DynamicParameters();
                    foreach (PropertyInfo item in item1.GetType().GetProperties().Where(s => !s.Name.In(toSkip)))
                    {
                        dP.Add(("@" + item.Name), item1.GetType().GetProperty(item.Name).GetValue(item1));
                    }
                    command.Add(dP);
                }
                return SqlConnection.Execute(cmd, command.ToArray(), commandType: commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "MultiRows");
                return 0;
            }
        }
        #endregion

        #region ScopeIdAsync
        public async Task<int> ExecuteProcedureGetScopeIdAsync(string cmd)
        {
            try
            {
                return await SqlConnection.QueryFirstAsync<int>(cmd);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteProcedureGetScopeIdAsync");
                return 0;
            }
        }
        public async Task<int> ExecuteProcedureGetScopeIdAsync(string cmd, DynamicParameters command)
        {
            try
            {
                return await SqlConnection.QueryFirstAsync<int>(cmd, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteProcedureGetScopeIdAsync");
                return 0;
            }
        }
        public async Task<int> ExecuteProcedureGetScopeIdAsync<T>(string cmd, T obj, string[] toSkip) where T : new()
        {
            try
            {
                DynamicParameters command = new DynamicParameters();
                foreach (PropertyInfo item in typeof(T).GetProperties().Where(s => !s.Name.In(toSkip)))
                {
                    command.Add(("@" + item.Name), obj.GetType().GetProperty(item.Name).GetValue(obj));
                }
                return await SqlConnection.QueryFirstAsync<int>(cmd, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteProcedureGetScopeId");
                return 0;
            }
        }
        #endregion

        #region Rows
        public long ExecuteDeleteProc(string cmd)
        {
            try
            {
                return SqlConnection.Execute(cmd);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteDeleteProc");
                return 0;
            }
        }
        public (bool, int) ExecuteCommandGetEfectedRows(string cmd)
        {
            try
            {
                int id = SqlConnection.Execute(cmd);
                return (id > 0, id);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "(bool, int) ExecuteCommandGetEfectedRows");
                return (false, 0);
            }
        }

        public int ExecuteGetRows(string cmd, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                return SqlConnection.Execute(cmd, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteGetRows");
                return 0;
            }
        }
        public int ExecuteGetRows(string cmd, CommandDefinition definition)
        {
            try
            {
                return SqlConnection.Execute(cmd, definition);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteGetRows");
                return 0;
            }
        }
        #endregion

        #region Fetch
        public T Get<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return SqlConnection.QueryFirstOrDefault<T>(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "Get");
            }
            return new T();
        }

        public IEnumerable<T> GetAll<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return SqlConnection.Query<T>(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetAll");
            }
            return new List<T>();
        }
        public T Get<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return SqlConnection.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "Get");
            }
            return new T();
        }

        public IEnumerable<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return SqlConnection.Query<T>(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetAll");
            }
            return new List<T>();
        }
        #endregion

        #region FetchAsync
        public async Task<T> GetAsync<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return (await SqlConnection.QueryAsync<T>(sp, parms, commandType: commandType)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetAsync");
            }
            return new T();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return (await SqlConnection.QueryAsync<T>(sp, parms, commandType: commandType));
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetAllAsync");
            }
            return new List<T>();
        }
        public async Task<T> GetAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return await SqlConnection.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetAsync");
            }
            return await Task.FromResult(new T());
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text) where T : new()
        {
            try
            {
                return (await SqlConnection.QueryAsync<T>(sp, parms, commandType: commandType));
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetAllAsync");
            }
            return new List<T>();
        }
        #endregion

        #region Logs
        public async void ErrorLog(Exception ex, string url)
        {
            try
            {
                //OpenConnection();
                string query = $"insertLog";
                DynamicParameters command = new();
                command.Add("@ShortMessage", ex.Message.Replace("'", "\""));
                await SqlConnection.ExecuteAsync(query, param: command, commandType: CommandType.StoredProcedure);
            }
            catch (Exception exx)
            {
                logger.LogError(exx, exx.InnerException?.Message ?? exx.Message, ex);
            }
        }
        public async Task ActivityLog(string comment)
        {
            try
            {
                string query = $"insert{nameof(ActivityLog)}";
                DynamicParameters command = new();
                command.Add("@Comment", comment);
                command.Add("@CreatedOnUtc", DateTime.UtcNow);
                await SqlConnection.ExecuteAsync(sql: query, param: command, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "/SqlFactory/ErrorLog");
            }
        }
        #endregion

        #region Generic
        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure) where T : new()
        {
            T result;
            try
            {
                result = SqlConnection.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "Insert");
                result = new T();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure) where T : new()
        {
            T result;
            try
            {
                result = SqlConnection.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "Update");
                result = new T();
            }
            return result;
        }
        #endregion

        #region Commons
        public GridReader QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                return SqlConnection.QueryMultiple(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "QueryMultiple");
                return default;
            }
        }
        public async Task<GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                return await SqlConnection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "QueryMultiple");
                return default;
            }
        }
        public GridReader QueryMultiple(string sql, CommandDefinition definition)
        {
            try
            {
                return SqlConnection.QueryMultiple(sql, definition);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "QueryMultiple");
                return default;
            }
        }
        public async Task<GridReader> QueryMultipleAsync(string sql, CommandDefinition definition)
        {
            try
            {
                return await SqlConnection.QueryMultipleAsync(sql, definition);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "QueryMultiple");
                return default;
            }
        }
        #endregion
    }
    public static class DapperExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<ISQLFactory, SQLFactory>();
            return services;
        }
        public static bool In(this object val,params object[] vals)
        {
            return vals.Contains(val);
        }
    }
}
