using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Principal;
using System.Data.Linq;
using LinqToDB.Mapping;

namespace DNELms.Keys
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [PrimaryKey, Identity]
        public long Id { get; set; }
        /// <summary>
        /// Get key for caching the entity
        /// </summary>
        //[NotMapped]
        //public string EntityCacheKey => GetEntityCacheKey(GetType(), Id);

        ///// <summary>
        ///// Get key for caching the entity
        ///// </summary>
        ///// <param name="entityType">Entity type</param>
        ///// <param name="id">Entity id</param>
        ///// <returns>Key for caching the entity</returns>
        //public static string GetEntityCacheKey(Type entityType, object id)
        //{
        //    return string.Format(NopCachingDefaults.NopEntityCacheKey, entityType.Name.ToLower(), id);
        //}
    }
    /// <summary>
    /// Represents default values related to caching
    /// </summary>
    public static partial class NopCachingDefaults
    {
        /// <summary>
        /// Gets the default cache time in minutes
        /// </summary>
        public static int CacheTime => 60;

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Entity type name
        /// {1} : Entity id
        /// </remarks>
        public static string NopEntityCacheKey => "Nop.{0}.id-{1}";
    }
}
