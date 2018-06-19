using System;
using System.Configuration;
using IotDataGenerator.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace IotDataGenerator.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger("Generator", (s, level) => true, true);
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            var app = new App(configurationBuilder.Build(), logger);
            app.Run().GetAwaiter().GetResult();
        }
    }
}
