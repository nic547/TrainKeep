using System;

namespace tklib
{
    public class TkSettings
    {
        public static string ConnectionString { get; set; }

        public static void SetConnectionString(string ip, string db, string user, string pw)
        {
            ConnectionString = BuildConnectionString(ip,db,user,pw);
        }
        public static string BuildConnectionString(string ip, string db, string user, string pw)
        {
            return $"Server={ip};User Id={user};Password={pw};Database={db};SSL Mode=Prefer;Trust Server Certificate=true;Application Name=TrainKeep;";
        }
    }
}
