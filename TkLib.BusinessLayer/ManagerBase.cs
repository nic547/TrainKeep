using System;
using TkLib.Dal;
namespace TkLib.BusinessLayer
{
    public class ManagerBase
    {
        
        public static void SetConnectionString(string hostname,string dbname, string username, string password)
        {
            TrainKeepContext.Hostname = hostname;
            TrainKeepContext.DatabaseName = dbname;
            TrainKeepContext.Username = username;
            TrainKeepContext.Password = password;
        }
    }
}
