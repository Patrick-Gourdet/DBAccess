
using Microsoft.Extensions.Configuration;

namespace DBAccessor
{
    /// <summary>
    /// Connection String Class to access the AppSettings.json file
    /// </summary>
    public class ConnectionString
    {
        public static string  Connect { get; set; } = string.Empty;
        public ConnectionString()
        {
            string c = Directory.GetCurrentDirectory();
            var root = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build(); 
            Connect = root["ConnectionStrings:DefaultConnection"] ?? throw new ArgumentNullException("Connection String is not found in appsettings.json");      
        }
    }
}