using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace POCWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            // [3insys]
            // configuring logging, this is for a calling application
            //.ConfigureLogging( log => 
            //{
            //    // Remove defautl configuration for logging
            //    log.ClearProviders(); 
            //    // add the console
            //    log.AddConsole();
            //    // add debug window logging
            //    log.AddDebug();

            //    // can be extended with custom loggers
            //    // or by adding the WindowsSystem log if applicable
            //}
          
    }
}
