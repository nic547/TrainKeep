// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    /// <summary>
    /// Represents a article produced by an manufacturer.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Gets or sets the Id of the model, given by the Database-System.
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string ItemCode { get; set; }

        /// <summary>
        /// Gets or Sets the reference to the prototype object, representing the real thing.
        /// </summary>
        public virtual Prototype Prototype { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Manufacturer} {this.ItemCode}: {this.Name}";
    }
}