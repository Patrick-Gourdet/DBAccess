
using Microsoft.Extensions.Configuration;

namespace DBAccessor
{
    /// <summary>
    /// Connection String Class to access the AppSettings.json file
    /// </summary>
    public static class ConnectionString
    {    
        public static string GetString()
        {
            var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build(); 
            return root["AppSettings:DefaultConnection"] ?? throw new ArgumentNullException("Connection String is not found in appsettings.json");      
        }
    }
}