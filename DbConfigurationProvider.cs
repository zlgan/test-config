using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Config
{
    public class DbConfigurationProvider:ConfigurationProvider
    {
        IDbConnection conn = new SqlConnection("server=localhost;Integrated Security=True;Initial Catalog=TestDb");

        public DbConfigurationProvider()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    Load();
                    base.OnReload();
                }
            });
        }
        public override void Load()
        {
            var config = conn.Query<ConfigEngity>("select * from Config")
                .ToDictionary(c => string.Join(":", new string[] { c.Category, c.Skey }), c => c.SValue);
            Data = config;
        }

    }
}
