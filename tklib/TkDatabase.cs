using Npgsql;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace tklib
{
    public class TkDatabase
    {
        public static string ConnectionString { get; set; }

        public static void SetConnectionString(string ip, string db, string user, string pw)
        {
            ConnectionString = BuildConnectionString(ip, db, user, pw);
        }
        public static string BuildConnectionString(string ip, string db, string user, string pw)
        {
            return $"Server={ip};User Id={user};Password={pw};Database={db};SSL Mode=Prefer;Trust Server Certificate=true;Application Name=TrainKeep;";
        }

        public static async Task<DbDataReader> ExecuteQueryAsync(string commandString)
        {
            var connection =
                new NpgsqlConnection(ConnectionString);
            await connection.OpenAsync();
            var command = new NpgsqlCommand(commandString, connection);
            return await command.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection); //The CloseConnection should close the connection once the datareader is disposed of
        }

        public static async void WarmupConnections()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            try
            {
                await connection.OpenAsync();
            }
            catch (Exception e) { Debug.WriteLine("Warmup: " + e.Message); }
            connection.Close();
        }
    }
}
