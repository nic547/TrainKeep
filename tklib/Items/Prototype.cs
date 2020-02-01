// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the real deal.
    /// </summary>
    public class Prototype
    {
        /// <summary>
        /// Gets or sets the database id of the object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Prototype.
        /// </summary>
        public string Name { get; set; }

        public int Weight { get; set; }

        public short Speed { get; set; }

        public short TractiveEffort { get; set; }

        public short Power { get; set; }

        /// <inheritdoc/>
        public override string ToString() => Name ?? string.Empty;
    }
}
