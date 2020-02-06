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
            Locomotives = new PgsqlItems("locomotive", this);
        }

        /// <inheritdoc/>
        public async override Task<ConnectionState> CheckConnectionState()
        {
            return await TestConnectionSettings(ConnectionSettings);
        }

        /// <inheritdoc/>
        public override async void WarmupConnectionsAsync()
        {
            var connection = new NpgsqlConnection(ConnectionSettings.ToConnectionString());
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

        /// <summary>
        /// Tests <see cref="DbsConnectionSettings"/> to see if a database can be found with these settings.
        /// </summary>
        /// <param name="connectionSettings">The settings one wants to test.</param>
        /// <returns>A <see cref="Task{ConnectionState}"/> representing the result of the asynchronous operation.</returns>
        public override async Task<ConnectionState> TestConnectionSettings(DbsConnectionSettings connectionSettings)
        {
            var connection = new NpgsqlConnection(connectionSettings.ToConnectionString());
            try
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT 1", connection);
                await command.ExecuteNonQueryAsync();
                command.Dispose();
                return ConnectionState.IsOK;
            }
            catch (PostgresException e) when (e.SqlState == "28P01")
            {
                return ConnectionState.FailurePassword;
            }
            catch (Exception e)
            {
                Debug.WriteLine("-- Unknown Exception in TestConnectionString() --");
                Debug.WriteLine(e.ToString());
                return ConnectionState.FailureUnspecified;
            }
            finally
            {
                connection.Dispose();
            }
        }

        /// <summary>
        /// Executes a string on the database.
        /// </summary>
        /// <param name="commandString">The query to be executed.</param>
        /// <returns>>A <see cref="Task"/> containing the resulting <see cref="DbDataReader"/>.</returns>
        internal async Task<DbDataReader> ExecuteQueryAsync(string commandString)
        {
            var connection = new NpgsqlConnection(ConnectionSettings.ToConnectionString());
            await connection.OpenAsync();
            var command = new NpgsqlCommand(commandString, connection);
            return await command.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection); // The CloseConnection should close the connection once the datareader is disposed of
        }
    }
}