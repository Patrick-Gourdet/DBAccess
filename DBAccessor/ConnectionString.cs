
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
            string c = Directory.GetCurrentDirectory();
            var root = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build(); 
            return root["ConnectionStrings:DefaultConnection"] ?? throw new ArgumentNullException("Connection String is not found in appsettings.json");      
        }
    }
}