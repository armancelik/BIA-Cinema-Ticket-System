using System;
using System.IO;
using BIA_Cinema_Ticket.SqlServerConnectionLibrary;
using Microsoft.Extensions.Configuration;


namespace SqlServerConnectionLibrary
{
    public class Helper
    {

        /// <summary>
        /// Configuration file name to read from.
        /// </summary>
       // public static string ConfigurationFileName { get; set; } = "appsettings.json";

        /// <summary>
        /// Must be first call to obtain properties
        /// </summary>
        //public static void Initializer()
        //{

        //    InitConfiguration();

        //    var setting = InitOptions<ConnectionStrings>("ConnectionStrings");

        //    DevelopmentConnectionString = setting.DevelopmentConnection;
            
        //}
        

        ///// <summary>
        ///// Development connection string
        ///// </summary>
        //public static string DevelopmentConnectionString { get; set; }
       
        ///// <summary>
        ///// Current connection string
        ///// </summary>
        //public static string ConnectionString { get; set; }
        ///// <summary>
        ///// Current environment
        ///// </summary>
       
        //private static IConfigurationRoot InitConfiguration()
        //{

        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile(ConfigurationFileName);

        //    return builder.Build();

        //}

        
        //public static T InitOptions<T>(string section) where T : new()
        //{
        //    var config = InitConfiguration();
        //    return config.GetSection(section).Get<T>();
        //}
    }
}
