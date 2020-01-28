// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.DbManager
{
    using Newtonsoft.Json;
    using Tklib.Db;

    /// <summary>
    /// Contains application logic related to databases.
    /// </summary>
    public static class DatabaseManager
    {
        private static Database Database { get; set; }

        /// <summary>
        /// Gets the database singleton.
        /// </summary>
        /// <returns>The <see cref="Database"/>-singleton.</returns>
        public static Database GetDatabase()
        {
            if (Database != null)
            {
                return Database;
            }
            else
            {
                Database = new Db.Pgsql.PgsqlDatabase();
                return Database;
            }
        }

        /// <summary>
        /// Serializes a <see cref="DbsConnectionSettings"/>.
        /// </summary>
        /// <param name="settings">The <see cref="DbsConnectionSettings"/> to be serialized.</param>
        /// <returns>A string containg the serialized input.</returns>
        public static string SerializeConnectionSettings(DbsConnectionSettings settings)
        {
            return JsonConvert.SerializeObject(settings);
        }

        /// <summary>
        /// Deserializes a string to a <see cref="DbsConnectionSettings"/>.
        /// </summary>
        /// <param name="settings">A string.</param>
        /// <returns><see cref="DbsConnectionSettings"/> or null.</returns>
        public static DbsConnectionSettings TryDeserializeConnectionSettings(string settings)
        {
            try
            {
                return JsonConvert.DeserializeObject<DbsConnectionSettings>(settings);
            }
            catch
            {
                return null;
            }
        }
    }
}
