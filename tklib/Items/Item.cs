// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Base class, represents one existing Item.
    /// </summary>
    public class Item : IEquatable<Item>, INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the id given to the Item by the Datbase-System.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the Item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the notes of the Item.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or Sets the DCC Adress.
        /// </summary>
        public int? Dcc { get; set; }

        /// <summary>
        /// Gets or sets the model this item is a instance of.
        /// </summary>
        public virtual Model Model { get; set; }

        /// <summary>
        /// Gets a Overivew Text for an Item.
        /// </summary>
        public string ItemOverview => $"{Model.Prototype.Name}\n{Model.Manufacturer} {Model.ItemCode}";

        /// <summary>
        /// Gets the Name of an Item, but falls back to the Name of the Model or even the prototype.
        /// </summary>
        public string VisibleName // Returns the Model.Name if the User hasn't set the Name of the actual Item
        {
            get
            {
                if (Name != string.Empty)
                {
                    return Name;
                }
                else
                {
                    return Model?.Name;
                }
            }
        }

        /// <summary>
        /// Gets or sets a jpg image of the Item.
        /// </summary>
        public byte[] Image { get; set; }

        

        /// <inheritdoc/>
        public bool Equals(Item item)
        {
            return Id == item.Id &&
                Name == item.Name &&
                Notes == item.Notes &&
                Dcc == item.Dcc &&
                Model.Equals(item.Model);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Item item))
            {
                return false;
            }
            else
            {
                return Equals(item);
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (Id, Name, Notes, Dcc, Model).GetHashCode();
        }

        /// <summary>
        /// Creates a deep copy of this Item.
        /// </summary>
        /// <returns><see cref="Item"/>.</returns>
        public Item Clone()
        {
            return new Item()
            {
                Id = Id,
                Name = Name,
                Notes = Notes,
                Dcc = Dcc,
                Model = Model.Clone(),
            };
        }

        /// <summary>
        /// Sets all values to those given by the <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The item containing the wanted values.</param>
        public void SetValuesTo(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Notes = item.Notes;
            Dcc = item.Dcc;
            Model.SetValuesTo(item.Model);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}