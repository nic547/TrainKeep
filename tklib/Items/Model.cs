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

        /// <summary>
        /// Gets or sets the name of the model.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the model.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the item code, SKU or however it's called.
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Gets or Sets the reference to the prototype object, representing the real thing.
        /// </summary>
        public virtual Prototype Prototype { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"{Manufacturer} {ItemCode}: {Name}";
    }
}