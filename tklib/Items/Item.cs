// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    using System.Threading.Tasks;

    /// <summary>
    /// Base class, represents one existing Item.
    /// </summary>
    public class Item
    {
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
    }
}