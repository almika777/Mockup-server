using Common.Enums;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;
using DataProcessor.Readers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModelReader(this IServiceCollection services)
        {
            services.AddScoped<FilterFactory>();
            return services.AddScoped<IModelReader>(x =>
            {
                var config = x.GetService<IApplicationConfig>();
                var filter = x.GetService<FilterFactory>();
                return config.ApplicationMode switch
                {
                    ApplicationMode.File => new FileModelReader(config, filter),
                    ApplicationMode.Files => new FilesModelReader(config),
                    ApplicationMode.Directory => new DirrectoryModelReader(config),
                    _ => throw new ArgumentOutOfRangeException(nameof(config.ApplicationMode), config.ApplicationMode, null)
                };
            });
        }
    }
}
