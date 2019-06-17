using System;
using System.Threading.Tasks;
using Tklib.Db;
using Npgsql;

namespace Tklib.Db.Pgsql
{
    public class PgsqlDatabase : Tklib.Db.Database
    {
        public PgsqlDatabase()
        {
            Locomotives = new Pgsql.PgsqlLocomotives();
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
