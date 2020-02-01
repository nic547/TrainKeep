// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Sqlite
{
    using System;
    using System.Threading.Tasks;
    using Tklib;

    /// <inheritdoc/>
    public class SqliteItems : Items
    {
        public SqliteItems(string vehicleType, Database database)
            : base(vehicleType, database)
        {
        }

        public override void Create(Item item)
        {
            throw new NotImplementedException();
        }

        public override void Create(Model model)
        {
            throw new NotImplementedException();
        }

        public override void Create(Prototype prototype)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Task Load()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Task LoadImage(Item item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
