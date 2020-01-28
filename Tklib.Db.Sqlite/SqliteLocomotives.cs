// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Sqlite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public class SqliteLocomotives : Locomotives
    {
        /// <inheritdoc/>
        public override Task Load()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Task LoadImage(Locomotive locomotive)
        {
            throw new NotImplementedException();
        }
    }
}
