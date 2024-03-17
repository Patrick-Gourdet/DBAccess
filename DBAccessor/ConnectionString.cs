
using System.Diagnostics;
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
            try
            {
                if(File.Exists($"{Directory.GetCurrentDirectory()}/AppSettings.json"))
                {
                    #if DEBUG
                    Debug.WriteLine("AppSettings.json file found");
                    #endif
                    var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build(); 
                    return root["AppSettings:DefaultConnection"] ??"";      
                }
                
                #if DEBUG
                Debug.WriteLine("AppSettings.json file not found");
                #endif
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}