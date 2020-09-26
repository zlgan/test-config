using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Config
{
    public class Config1
    {
        public static void Test1()
        {
            //var source = new Dictionary<string, string>
            //{
            //    ["host1:id"] = "1",
            //    ["host1:name"] = "a",
            //    ["host2:id"] = "2",
            //    ["host2:name"] = "b"
            //};

            var config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddDbConfig()
                  //.AddInMemoryCollection(source)
                  .Build();


            //var test = config.GetSection("host").Get<Hosts[]>();






            //ChangeToken.OnChange(()=> config.GetReloadToken(), () => {

            //    var bb = config.GetSection("app").GetValue<string>("name");
            //    var ddd = config.GetSection("mycofig").GetValue<string>("name");
            //    Console.WriteLine(bb);
            //    Console.WriteLine(ddd);


            //});


            var myOptoin = new ServiceCollection()
                .AddOptions()
                //.Configure<AppInfo>(config.GetSection("app"))
                .Configure<AppInfo>(config.GetSection("app"))
                .Configure<myconfig>(config.GetSection("myconfig"))
                .BuildServiceProvider();


            Task.Run(() => {

                while (true)
                {
                    Thread.Sleep(2000);
                    var dd = myOptoin.GetRequiredService<IOptionsMonitor<AppInfo>>().CurrentValue;
                    var aa = myOptoin.GetRequiredService<IOptionsMonitor
                        
                        
                        <myconfig>>().CurrentValue;
                    Console.WriteLine(aa.name);
                    Console.WriteLine(dd.age);
                }
            });
        }
    }
}
