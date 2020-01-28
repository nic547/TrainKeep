// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Sqlite
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of basic database operations for SQLite.
    /// </summary>
    public class SqlliteDatabase : Database
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlliteDatabase"/> class.
        /// </summary>
        public SqlliteDatabase()
        {
            Locomotives = new SqliteLocomotives();
        }

        /// <inheritdoc/>
        public override Task<ConnectionState> CheckConnectionState()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void CloseConnections()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void SetConnectionSettings(string path, string dbname = "", string username = "", string password = "")
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Task<ConnectionState> TestConnectionSettings(string path, string dbname, string username, string password)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void WarmupConnectionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
