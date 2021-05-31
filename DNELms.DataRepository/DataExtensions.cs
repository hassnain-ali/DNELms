using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNELms.DataRepository
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataRepositry(this IServiceCollection services)
        {
            return services.AddSingleton<INopDataProvider, MsSqlNopDataProvider>()
                 .AddSingleton(typeof(IRepository<>), typeof(EntityRepository<>));
        }
    }
}
