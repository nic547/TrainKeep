// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db
{
    using System.Threading.Tasks;

    /// <summary>
    /// The database used by TrainKeep.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        /// Gets or sets the object containing everything related to Locomotives.
        /// </summary>
        public Items Locomotives { get; set; }

        /// <summary>
        /// Gets or sets the connections settings of this database.
        /// </summary>
        public DbsConnectionSettings ConnectionSettings { get; set; }

        /// <summary>
        /// Tests a connection string.
        /// </summary>
        /// <param name="connectionSettings">Path or URL to the Database(-server).</param>
        /// <returns><see cref="ConnectionState"/>describing the result.</returns>

        /// <returns><see cref="ConnectionState"/> describing the result.</returns>
        public abstract Task<ConnectionState> TestConnectionSettings(DbsConnectionSettings connectionSettings);

        /// <summary>
        /// Checks the current state of the connection.
        /// </summary>
        /// <returns><see cref="ConnectionState"/> describing the result.</returns>
        public abstract Task<ConnectionState> CheckConnectionState();

        /// <summary>
        /// Tries to prepare the connection for usage, for example by already opening a bunch of connections and putting them into a connection pool.
        /// Idealy this should reduce the overhead of the first request.
        /// </summary>
        public abstract void WarmupConnectionsAsync();

        /// <summary>
        /// Closes all open Connections.
        /// </summary>
        public abstract void CloseConnections();
    }
}
