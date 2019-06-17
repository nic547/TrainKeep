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
        public Locomotives Locomotives { get; set; }

        /// <summary>
        /// Sets the connection string.
        /// </summary>
        /// <param name="path">Path or URL to the Database(-server).</param>
        /// <param name="dbname">Name of the database, if applicable.</param>
        /// <param name="username">Username, if applicable.</param>
        /// <param name="password">Password, if applicable.</param>
        public abstract void SetConnectionString(string path, string dbname = "", string username = "", string password = "");

        /// <summary>
        /// Tests a connection string.
        /// </summary>
        /// <param name="path">Path or URL to the Database(-server).</param>
        /// <param name="dbname">Name of the database, if applicable.</param>
        /// <param name="username">Username, if applicable.</param>
        /// <param name="password">Password, if applicable.</param>
        /// <returns><see cref="ConnectionState"/> describing the result.</returns>
        public abstract ConnectionState TestConnectionString(string path, string dbname = "", string username = "", string password = "");

        /// <summary>
        /// Checks the current state of the connection.
        /// </summary>
        /// <returns><see cref="ConnectionState"/> describing the result.</returns>
        public abstract ConnectionState CheckConnectionState();

        /// <summary>
        /// Tries to prepare a Database for usage, for example by already opening connections and putting them into a connection pool
        /// The goal is to be ready when the first data is requested.
        /// </summary>
        public abstract void WarmupConnectionsAsync();

        /// <summary>
        /// Closes all open Connections.
        /// </summary>
        public abstract void CloseConnections();
    }
}
