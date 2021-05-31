using Autofac;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;

namespace DNELms.Core.Infrastructure
{
    public interface IEngine
    {
        IServiceProvider ServiceProvider { get; set; }

        void RegisterDependencies(ContainerBuilder containerBuilder, IServiceProvider provider);
        object Resolve(Type type);
        T Resolve<T>() where T : class;
        IEnumerable<T> ResolveAll<T>();
        object ResolveUnregistered(Type type);
        string DefaultConnectionString { get; }
        IHostingEnvironment HostingEnvironment { get; }
    }
}