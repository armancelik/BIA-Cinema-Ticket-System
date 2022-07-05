using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket
{
    public class Program
    {
        private static string _ConnectionString;   //
        public static string ConnectionString
        {     //
            get {
                return _ConnectionString;
            } set{
                _ConnectionString=value;
            } 
        }
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
      
      
    }
}
