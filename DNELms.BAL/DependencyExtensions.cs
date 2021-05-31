using DNELms.BAL.WorldRepo;
using Fyp.BAL.CategoriesRepo;
using Microsoft.Extensions.DependencyInjection;

namespace DNELms.BAL
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            //services.AddSingleton<CategoriesRepo>();
            return services.AddSingleton<ICategoriesService, CategoriesService>()
                .AddSingleton<IStatesService, StatesService>()
                .AddSingleton<ICitiesService, CitiesService>()
                .AddSingleton<ICountriesService, CountriesService>();
        }
    }
}
