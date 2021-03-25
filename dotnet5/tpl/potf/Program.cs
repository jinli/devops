using Microsoft.Extensions.Configuration;
using System;

namespace POTF
{
    class Program
    {
        private static IConfiguration Configuration;
        static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                //.AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var section = Configuration.GetSection("AppSettings:token");
            
            Console.WriteLine(section.Value);
        }
    }
}
