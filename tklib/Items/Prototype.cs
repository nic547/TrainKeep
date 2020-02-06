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

        /// <summary>
        /// Gets or sets the weight of the prototype. Assumed to be in kg.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the speed of the prototype. Assumed to be in km/h.
        /// </summary>
        public short Speed { get; set; }

        /// <summary>
        /// Gets or Sets the tractive effort of the prototype. Assumed to be in kN.
        /// </summary>
        public short TractiveEffort { get; set; }

        /// <summary>
        /// Gets or sets the power of the prototype. Assumed to be in kW.
        /// </summary>
        public short Power { get; set; }

        /// <inheritdoc/>
        public override string ToString() => Name ?? string.Empty;
    }
}
