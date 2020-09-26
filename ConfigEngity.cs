using System;
using System.Collections.Generic;
using System.Text;

namespace Config
{
    public class ConfigEngity
    {
        public string Category { get; set; }
        public string Skey { get; set; }
        public string SValue { get; set; }
    }


    public class DbSettings
    {
        public AppInfo app { get; set; }
        public globalinfo global { get; set; }
    }


    public class AppInfo
    {
        public string name { get; set; }
        public string age { get; set; }
    }

    public class AppInfo1
    {
        public string name { get; set; }
    }

    public class globalinfo
    {
        public string height { get; set; }
        public string weight { get; set; }
    }


    public class Hosts
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class myconfig
    {
        public string name { get; set; }
    }
}
