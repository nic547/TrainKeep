using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using tklib;

namespace tklib.db
{
    public abstract class Database
    {
        public abstract ConnectionState CheckConnectionState();

        /// <summary>
        /// Tries to prepare a Database for usage, for example by already opening connections and putting them into a connection pool
        /// The goal is to be ready when the first data is requested
        /// </summary>
        /// <returns></returns>
        public abstract Task WarmupConnections();

        public abstract void CloseConnections();

        public Locomotives Locomotives { get; set; }
        
    }
}
