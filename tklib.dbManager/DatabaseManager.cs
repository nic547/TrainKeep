using System;
using System.Collections.Generic;
using System.Text;

namespace tklib.db
{
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
                Database = new pgsql.PgsqlDatabase();
                return Database;
            }
        }
    }
}
