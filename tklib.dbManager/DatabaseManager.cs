namespace Tklib.DbManager
{
    using Newtonsoft.Json;
    using Tklib.Db;

    public static class DatabaseManager
    {
        private static Database Database { get; set; }

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
