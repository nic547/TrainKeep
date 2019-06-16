using System;
using System.Threading.Tasks;
using tklib.db;
using Npgsql;

namespace tklib.db.pgsql
{
    public class PgsqlDatabase : tklib.db.Database
    {
        public PgsqlDatabase()
        {
            Locomotives = new pgsql.PgsqlLocomotives();
        }

        public override ConnectionState CheckConnectionState()
        {
            throw new NotImplementedException();
        }

        public override Task WarmupConnections()
        {
            throw new NotImplementedException();
        }

        public override void CloseConnections()
        {
            NpgsqlConnection.ClearAllPools();
        }
    }
}
