using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Config
{
    public class ConfigurationChangeTokenSource<TOptions> : IOptionsChangeTokenSource<TOptions>
    {
        IConfiguration _config;
        public string Name { get; }

        public ConfigurationChangeTokenSource(string name,IConfiguration config)
        {
            _config = config;
            Name = name ?? Options.DefaultName;
        }
        public IChangeToken GetChangeToken()
        {
            return _config.GetReloadToken();
        }
    }

    //public static class OptionsConfigurationServiceCollectionExtensions
    //{
    //    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, IConfiguration config) where TOptions : class
    //    {
    //        return services.Configure<TOptions>(Options.DefaultName, config);
    //    }

    //    public static IServiceCollection Configure<TOptions>(this IServiceCollection services,string name, IConfiguration config) where TOptions : class
    //    {
    //        return services.AddSingleton<IOptionsChangeTokenSource<TOptions>>(new ConfigurationChangeTokenSource<TOptions>(name, config))
    //            .AddSingleton<IConfigureOptions<TOptions>>(new NamedConfigureFromConfigurationOptions<TOptions>(name,config));
    //    }
    //}

}
