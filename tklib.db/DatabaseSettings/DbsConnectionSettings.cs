// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the settings of a connection to a specific database system.
    /// </summary>
    public class DbsConnectionSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbsConnectionSettings"/> class.
        /// </summary>
        /// <param name="name"><see cref="Name"/>.</param>.
        public DbsConnectionSettings(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of this type of ConnectionString. Ex. "PostgreSQL" or "SQLite in-memory".
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a List of options for the connectionString.
        /// </summary>
        public IList<SingleDatabaseSetting> Settings { get; } = new List<SingleDatabaseSetting>();

        /// <summary>
        /// The ConnectionString.
        /// </summary>
        /// <returns>A string contain the connectionString with the given settings.</returns>
        public string ToConnectionString()
        {
            string result = string.Empty;

            foreach (var setting in Settings)
            {
                result += setting.ToConnectionString();
            }

            return result;
        }
    }
}