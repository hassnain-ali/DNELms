using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNELms.Core.Infrastructure
{
    /// <summary>
    /// Represents Nop engine
    /// </summary>
    public class Engine : IEngine
    {
        #region Fields

        //private ITypeFinder _typeFinder;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets service provider
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        #endregion

        #region Utilities

        /// <summary>
        /// Get IServiceProvider
        /// </summary>
        /// <returns>IServiceProvider</returns>
        protected IServiceProvider GetServiceProvider()
        {
            if (ServiceProvider == null)
                return null;
            var accessor = ServiceProvider?.GetService<IHttpContextAccessor>();
            var context = accessor?.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="containerBuilder">Container builder</param>
        /// <param name="nopConfig">Nop configuration parameters</param>
        public virtual void RegisterDependencies(ContainerBuilder containerBuilder, IServiceProvider provider)
        {
            //register engine
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();
            containerBuilder.RegisterInstance(provider).AsSelf().SingleInstance();
            ServiceProvider = provider;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">Type of resolved service</typeparam>
        /// <returns>Resolved service</returns>
        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <param name="type">Type of resolved service</param>
        /// <returns>Resolved service</returns>
        public object Resolve(Type type)
        {
            var sp = GetServiceProvider();
            if (sp == null)
                return null;
            return sp.GetService(type);
        }

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">Type of resolved services</typeparam>
        /// <returns>Collection of resolved services</returns>
        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        /// <summary>
        /// Resolve unregistered service
        /// </summary>
        /// <param name="type">Type of service</param>
        /// <returns>Resolved service</returns>
        public virtual object ResolveUnregistered(Type type)
        {
            Exception innerException = null;
            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    //try to resolve constructor parameters
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null)
                            throw new Exception("Unknown dependency");
                        return service;
                    });

                    //all is ok, so create instance
                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }

            throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
        }

        IHostingEnvironment _hostingEnvironment;

        public virtual IHostingEnvironment HostingEnvironment
        {
            get
            {
                if (_hostingEnvironment != null)
                {
                    _hostingEnvironment = Resolve<IHostingEnvironment>();
                }
                return _hostingEnvironment;
            }
        }
        string _connectionString;
        public virtual string DefaultConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    _connectionString = Resolve<IConfiguration>().GetConnectionString("DefaultConnection");
                }
                return _connectionString;
            }
        }
        #endregion

    }
}
