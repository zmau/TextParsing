using Microsoft.Extensions.DependencyInjection;
using TextParsingServer.Servces.WordCounter;

namespace TextParsingServer.Servces
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWordCounter, WordCounter.WordCounter>();
        }
    }
}
