using System.Data.SqlClient;

namespace DBAccessor
{
    /// <summary>
    /// DBAccesses class to access the connection string and the connection to the database
    /// </summary>
    public class DBAccess
    {
        public static string Connect { get=>ConnectionString.GetString(); set => Connect =  value; }
        
    }

    /// <summary>
    /// ConnectionAccess class to connect to the database
    /// </summary>
    public static class ConnectionAccess
    {
        private static SqlConnection? conn;

        public static  SqlConnection ConnectToDB(this string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open(); 
            return conn;
        }
        public static async Task<SqlConnection> ConnectToDBAsync(this string connectionString)
        {
            conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            return conn;
        }
    }

    /// <summary>
    /// ComposeCommand class to compose the SqlCommand
    /// </summary>
    public static class AccessCommand
    {
        public static SqlCommand ComposeCommand(this SqlConnection connection, string command)
        {
            return new(command, connection);
        }
    }

    /// <summary>
    /// AddParam class to add parameters to the SqlCommand
    /// </summary>
    public static class AddParam
    {
        public static SqlCommand WithParam(this SqlCommand command, string param, System.Data.SqlDbType sqlDataTYpe, object value)
        {
            try
            {
                // Get the value type and convert it to the correct type for the database
                Type? valueType = (value is null ? null : value.GetType()) ?? throw new ArgumentNullException("Value is null");
                var changedType = Convert.ChangeType(value, valueType);

                command.Parameters.Add(param, sqlDataTYpe, int.MaxValue);
                command.Parameters[param].Value = changedType;
            }
            catch
            {
                throw;
            }
            return command;
        }
    }
}