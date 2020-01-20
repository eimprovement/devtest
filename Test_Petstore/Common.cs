using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Petstore
{
    public static class Common
    {

      
      
        public static string GetAppSetting(string keyName)
        {
            var archivo = "appsettings.json";
            var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(ambiente))
                archivo = $"appsettings.{ambiente}.json";

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(archivo);

            IConfigurationRoot Configuration;

            Configuration = builder.Build();

            return Configuration[keyName].ToString().Trim();
        }

       

    }
}
