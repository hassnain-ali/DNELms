using Dapper;
using DNELms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DNELms.Dapper
{
    public interface ISQLFactory
    {
        Task ActivityLog(string comment);
        void ErrorLog(Exception ex, string url);
        (bool, int) ExecuteCommandGetEfectedRows(string cmd);
        long ExecuteDeleteProc(string cmd);
        int ExecuteGetRows(string cmd, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        int ExecuteGetRows(string cmd, CommandDefinition definition);
        (bool, int) ExecuteProcedureGetScopeId(string cmd);
        (bool, int) ExecuteProcedureGetScopeId(string cmd, DynamicParameters command);
        int ExecuteProcedureGetScopeId<T>(string cmd, T obj, string[] toSkip) where T : new();
        Task<int> ExecuteProcedureGetScopeIdAsync(string cmd);
        Task<int> ExecuteProcedureGetScopeIdAsync(string cmd, DynamicParameters command);
        Task<int> ExecuteProcedureGetScopeIdAsync<T>(string cmd, T obj, string[] toSkip) where T : new();
        T Get<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text) where T : new();
        T Get<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new();
        IEnumerable<T> GetAll<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new();
        IEnumerable<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text) where T : new();
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new();
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text) where T : new();
        Task<T> GetAsync<T>(string sp, DynamicParameters parms = null, CommandType commandType = CommandType.Text) where T : new();
        Task<T> GetAsync<T>(string sp, object parms = null, CommandType commandType = CommandType.Text) where T : new();
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure) where T : new();
        int MultiRows<T>(string cmd, List<T> obj, CommandType commandType = CommandType.StoredProcedure, string[] toSkip = null) where T : new();
        SqlMapper.GridReader QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        SqlMapper.GridReader QueryMultiple(string sql, CommandDefinition definition);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, CommandDefinition definition);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure) where T : new();

        Task<IEnumerable<T>> SelectAsync<T>(string sp, PagingVM parms = default, bool hasActiveParam = true, bool? isActive = null, Dictionary<string, object> additional = null) where T : DTModel, new();
    }
}