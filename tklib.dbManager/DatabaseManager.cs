using System;
using System.Collections.Generic;
using System.Text;

namespace Tklib.Db
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
                Database = new Pgsql.PgsqlDatabase();
                return Database;
            }
        }
    }
}
