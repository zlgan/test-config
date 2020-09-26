using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Config
{
    public static class DbConfigurationExtensions
    {
        public static IConfigurationBuilder AddDbConfig(this IConfigurationBuilder builder)
        {
            var source = new DbConfigurationSource();
            builder.Add(source);
            return builder;
        }
    }
}
