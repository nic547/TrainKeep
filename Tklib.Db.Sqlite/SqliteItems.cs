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
        /// <summary>
        /// Initializes a new instance of the <see cref="SqliteItems"/> class.
        /// </summary>
        /// <param name="vehicleType">The type of vehicles this object is repsonsible for.</param>
        /// <param name="database">The database.</param>
        public SqliteItems(string vehicleType, Database database)
            : base(vehicleType, database)
        {
        }

        /// <inheritdoc/>
        public override void Insert(Item item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Insert(Model model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Insert(Prototype prototype)
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

        /// <inheritdoc/>
        public override void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
