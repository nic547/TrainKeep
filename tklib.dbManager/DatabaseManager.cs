namespace Tklib.DbManager
{
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
    }
}
