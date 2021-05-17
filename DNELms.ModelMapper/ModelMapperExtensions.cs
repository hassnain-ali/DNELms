using Microsoft.Extensions.DependencyInjection;

namespace DNELms.ModelMappers
{
    public static class ModelMapperExtensions
    {
        /// <summary>
        /// adds <seealso cref="IModelMapper"/> as singlton
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddModelMapper(this IServiceCollection services)
        {
            services.AddSingleton<IModelMapper, ModelMapper>();
            return services;
        }
    }
}
