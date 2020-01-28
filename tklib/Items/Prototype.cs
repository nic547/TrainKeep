// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

#nullable enable

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
        /// Initializes a new instance of the <see cref="Prototype"/> class.
        /// </summary>
        /// <param name="id"><see cref="Id"/>.</param>
        /// <param name="name"><see cref="Name"/>.</param>
        public Prototype(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets or sets the database id of the object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Prototype.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets <see cref="PrototypeAdvanced"/>.
        /// </summary>
        public PrototypeAdvanced? Advanced { get; set; }

        /// <inheritdoc/>
        public override string ToString() => Name;
    }
}
