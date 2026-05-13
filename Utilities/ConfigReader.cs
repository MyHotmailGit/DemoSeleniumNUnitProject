using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumNUnitProject.Utilities
{
    public static class ConfigReader
    {
        private static IConfiguration _config;

        static ConfigReader()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false)
                .Build();
        }

        public static string BaseUrl =>
            _config["Application:BaseUrl"];

        public static string BrowserName =>
            _config["Browser:Name"];

        public static bool Headless =>
            bool.Parse(_config["Browser:Headless"]);

        public static int ImplicitWait =>
            int.Parse(_config["Timeouts:ImplicitWait"]);
    }
}
