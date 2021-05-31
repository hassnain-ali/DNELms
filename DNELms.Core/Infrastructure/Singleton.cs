using System;
using System.Collections.Generic;
using System.Text;

namespace DNELms.Core.Infrastructure
{
    public class Singleton<T> : BaseSingleton
    {
        private static T instance;

        /// <summary>
        /// The singleton instance for the specified type T. Only one instance (at the time) of this object for each type of T.
        /// </summary>
        public static T Instance
        {
            get => instance;
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
    /// <summary>
    /// Provides access to all "singletons" stored by <see cref="Singleton{T}"/>.
    /// </summary>
    public class BaseSingleton
    {
        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Dictionary of type to singleton instances.
        /// </summary>
        public static IDictionary<Type, object> AllSingletons { get; }
    }
}
