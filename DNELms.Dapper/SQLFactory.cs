using Dapper;
using DNELms.Keys;
using DNELms.Models;
using DNELms.Services;
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
        public async Task<T> UpdateEntityAsync<T>(string cmd, T obj) where T : BaseEntity, new()
        {
            try
            {
                DynamicParameters command = new();
                foreach (PropertyInfo item in typeof(T).GetProperties())
                {
                    command.Add(("@" + item.Name), obj.GetType().GetProperty(item.Name).GetValue(obj));
                }
                await SqlConnection.QueryFirstAsync<int>(cmd, param: command, commandType: CommandType.StoredProcedure);
                return obj;
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "ExecuteProcedureGetScopeId");
                return obj;
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

        public Task<int> ExecuteNonQuery(string query)
        {
            return SqlConnection.ExecuteAsync(new CommandDefinition(query));
        }
        public Task<IDataReader> ExecuteDataReader(string query)
        {
            return SqlConnection.ExecuteReaderAsync(new CommandDefinition(query));
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
                return (await SqlConnection.QueryAsync<T>(sp, parms, commandTimeout: 500, commandType: commandType));
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



        public async Task<IEnumerable<T>> SelectAsync<T>(string sp, PagingVM parms = default, bool hasActiveParam = true, bool? isActive = null, Dictionary<string, object> additional = null) where T : DTModel, new()
        {
            try
            {
                DynamicParameters @params = new();
                @params.Add("DisplayLength", parms.DisplayLength, DbType.Int32);
                @params.Add("DisplayStart", parms.DisplayStart, DbType.Int32);
                @params.Add("SortCol", parms.SortCol?.ToLower(), DbType.String);
                @params.Add("SortOrder", parms.SortOrder?.ToLower(), DbType.String);
                @params.Add("Search", parms.Query, DbType.String);
                if (hasActiveParam)
                {
                    @params.Add("Active", isActive, DbType.Boolean);
                }
                foreach (var item in additional ?? new())
                {
                    @params.Add(item.Key, item.Value);
                }
                return await SqlConnection.QueryAsync<T>(sp, @params, commandTimeout: 250, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "SelectAsync");
            }
            return Enumerable.Empty<T>();
        }
        #endregion

        #region Logs
        public Task ErrorLog(Exception ex, string url)
        {
            try
            {
                //OpenConnection();
                string query = $"insertErrorLog";
                DynamicParameters command = new();
                command.Add("@Message", ex.Message.Replace("'", "\""));
                command.Add("@IpAddress", accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                command.Add("@CreateDate", DateTime.UtcNow);
                command.Add("@Url", url);
                command.Add("@User_Id", accessor.HttpContext.User.UserId());
                return SqlConnection.ExecuteAsync(query, param: command, commandType: CommandType.StoredProcedure);
            }
            catch (Exception exx)
            {
                logger.LogError(exx, exx.InnerException?.Message ?? exx.Message, ex);
                return Task.CompletedTask;
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
                await ErrorLog(ex, "/SqlFactory/ErrorLog");
            }
        }
        #endregion

        #region Generic
        public async Task<T> Insert<T>(string sp, T model) where T : BaseEntity, new()
        {
            try
            {
                DynamicParameters command = new();
                Type type = model.GetType();
                foreach (PropertyInfo item in typeof(T).GetProperties().Where(s => s.Name != "Id"))
                {
                    command.Add(("@" + item.Name), type.GetProperty(item.Name).GetValue(model));
                }
                long id = await SqlConnection.QueryFirstAsync<long>(sp, command, commandType: CommandType.StoredProcedure);
                model.Id = id;
                return model;
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "Insert");
                return new T();
            }
        }

        public async Task<T> Update<T>(string sp, T model) where T : BaseEntity, new()
        {
            try
            {
                DynamicParameters command = new();
                Type type = model.GetType();
                foreach (PropertyInfo item in typeof(T).GetProperties())
                {
                    command.Add(("@" + item.Name), type.GetProperty(item.Name).GetValue(model));
                }
                long id = await SqlConnection.QueryFirstAsync<long>(sp, command, commandType: CommandType.StoredProcedure);
                model.Id = id;
                return model;
            }
            catch (Exception ex)
            {
                await ErrorLog(ex, "Update");
                return new T();
            }
        }
        public Task<T> GetByIdAsync<T>(long id, string tableName = "") where T : BaseEntity, new()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    Type type = typeof(T);
                    tableName = type.Name;
                }
                return SqlConnection.QueryFirstAsync<T>($"select * from {tableName} where {nameof(BaseEntity.Id)}=@id", new { id }, commandType: CommandType.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex, "GetByIdAsync");
                return Task.FromResult<T>(new());
            }
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
        public static bool In(this object val, params object[] vals)
        {
            return vals.Contains(val);
        }
    }
}
