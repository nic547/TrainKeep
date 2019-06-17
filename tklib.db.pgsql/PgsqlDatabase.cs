// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Pgsql
{
    using System;
    using System.Data.Common;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Npgsql;

    /// <summary>
    /// The Database used by TrainKeep, here PostgreSQL.
    /// </summary>
    public class PgsqlDatabase : Database
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PgsqlDatabase"/> class.
        /// </summary>
        public PgsqlDatabase()
        {
            this.Locomotives = new Pgsql.PgsqlLocomotives(this);
        }

        private string ConnectionString { get; set; }

        /// <inheritdoc/>
        public override ConnectionState CheckConnectionState()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override async void WarmupConnectionsAsync()
        {
            var connection = new NpgsqlConnection(this.ConnectionString);
            try
            {
                await connection.OpenAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Warmup: " + e.Message);
            }

            connection.Close();
        }

        /// <inheritdoc/>
        public override void CloseConnections()
        {
            NpgsqlConnection.ClearAllPools();
        }

        /// <inheritdoc/>
        public override void SetConnectionString(string path, string dbname = "", string username = "", string password = "")
        {
            this.ConnectionString = this.BuildConnectionString(path, dbname, username, password);
        }

        /// <inheritdoc/>
        public override ConnectionState TestConnectionString(string path, string dbname = "", string username = "", string password = "")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes a string on the database.
        /// </summary>
        /// <param name="commandString">The query to be executed.</param>
        /// <returns>>A <see cref="Task"/> containing the resulting <see cref="DbDataReader"/>.</placeholder></returns>
        internal async Task<DbDataReader> ExecuteQueryAsync(string commandString)
        {
            var connection =
                new NpgsqlConnection(this.ConnectionString);
            await connection.OpenAsync();
            var command = new NpgsqlCommand(commandString, connection);
            return await command.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection); // The CloseConnection should close the connection once the datareader is disposed of
        }

        private string BuildConnectionString(string path, string dbname, string username, string password)
        {
            return $"Server={path};User Id={username};Password={password};Database={dbname};SSL Mode=Prefer;Trust Server Certificate=true;Application Name=TrainKeep;";
        }
    }
}
