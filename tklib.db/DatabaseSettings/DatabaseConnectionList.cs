// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a list of possible DatabaseConnections.
    /// </summary>
    public static class DatabaseConnectionList
    {
        /// <summary>
        /// Gets a list of all types of connections strings available.
        /// </summary>
        /// <returns>List of ConnectionStrings.</returns>
        public static IList<DbsConnectionSettings> Get()
        {
            var list = new List<DbsConnectionSettings>
            {
                new DbsConnectionSettings("PostgreSQL")
                {
                    Settings =
                    {
                        new SingleDatabaseSetting
                        {
                           Setting = "Host",
                           Value = "127.0.0.0",
                           DisplayToUser = true,
                        },

                        new SingleDatabaseSetting
                        {
                            Setting = "Database",
                            Value = "trainkeep",
                            DisplayToUser = true,
                        },

                        new SingleDatabaseSetting
                        {
                            Setting = "Username",
                            Value = "tk_user",
                            DisplayToUser = true,
                        },

                        new SingleDatabaseSetting
                        {
                            Setting = "Password",
                            Value = "tk_user01",
                            DisplayToUser = true,
                        },

                        new SingleDatabaseSetting
                        {
                            Setting = "SSL Mode",
                            Value = "Prefer",
                            DisplayToUser = false,
                        },

                        new SingleDatabaseSetting
                        {
                            Setting = "Trust Server Certificate",
                            Value = "true",
                            DisplayToUser = false,
                        },
                    },
                },
            };

            return list;
        }
    }
}
