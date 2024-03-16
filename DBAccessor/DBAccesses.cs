namespace DBAccessor;
using System.Data.SqlClient;


    public class DBAccesses
    {

        public static string Connect { get; set; } = string.Empty;

    #nullable enable
        public static SqlConnection? Connection { get; set; }
        public static SqlCommand? Command { get; set; }
    }
    public static class ConnectionAccess
    {
        public static SqlConnection conn;

        public static async Task<SqlConnection> ConnectToDB(this string connectionString)
        {
            conn = new SqlConnection(connectionString);
            await conn.OpenAsync(); return conn;
        }
    }

    public static class AccessCommand
    {
        public static SqlCommand ComposeCommand(this SqlConnection connection, string command)
        {
            return new(command, connection);
        }
    }

    public static class AddParam
    {
        public static SqlCommand WithParam(this SqlCommand command, string param, System.Data.SqlDbType sqlDataTYpe, object value)
        {
            try
            {
                Type bla = value is null ? null : value.GetType();
                var g = Convert.ChangeType(value, bla);

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


