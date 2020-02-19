// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    using System;

    /// <summary>
    /// Represents a article produced by an manufacturer.
    /// </summary>
    public class Model : IEquatable<Model>
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

        /// <inheritdoc/>
        public bool Equals(Model model)
        {
            return
                Id == model.Id &&
                Name == model.Name &&
                Manufacturer == model.Manufacturer &&
                ItemCode == model.ItemCode &&
                Prototype.Equals(model.Prototype);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Model model))
            {
                return false;
            }
            else
            {
                return Equals(model);
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
           return (Id, Name, Manufacturer, ItemCode, Prototype).GetHashCode();
        }

        /// <summary>
        /// Creates a deep copy of this Model.
        /// </summary>
        /// <returns>A <see cref="Model"/>.</returns>
        public Model Clone()
        {
            return new Model()
            {
                Id = Id,
                Name = Name,
                Manufacturer = Manufacturer,
                ItemCode = ItemCode,
                Prototype = Prototype.Clone(),
            };
        }

        /// <summary>
        /// Sets all values to those given by the <see cref="Model"/>.
        /// </summary>
        /// <param name="model">The model containing the wanted values.</param>
        public void SetValuesTo(Model model)
        {
            Id = model.Id;
            Name = model.Name;
            Manufacturer = model.Manufacturer;
            ItemCode = model.ItemCode;
            Prototype.SetValuesTo(model.Prototype);
        }
    }
}