using System.Data.SqlClient;

namespace DBAccessor
{
    /// <summary>
    /// DBAccesses class to access the connection string and the connection to the database
    /// </summary>
    public class DBAccesses
    {
        public static string Connect { get; set; } = string.Empty;

        #nullable enable
        public static SqlConnection? Connection { get; set; }
        public static SqlCommand? Command { get; set; }
    }

    /// <summary>
    /// ConnectionAccess class to connect to the database
    /// </summary>
    public static class ConnectionAccess
    {
        public static SqlConnection? Conn;

        public static async Task<SqlConnection> ConnectToDB(this string connectionString)
        {
            Conn = new SqlConnection(connectionString);
            await Conn.OpenAsync();
            return Conn;
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
                var g = Convert.ChangeType(value, valueType);

                command.Parameters.Add(param, sqlDataTYpe, int.MaxValue);
                command.Parameters[param].Value = g;
            }
            catch
            {
                throw;
            }
            return command;
        }
    }
}