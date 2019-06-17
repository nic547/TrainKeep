// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib
{
    using System.Threading.Tasks;

    /// <summary>
    /// Base class, represents one existing Item.
    /// </summary>
    public abstract class Item
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
        /// Gets or sets the model this item is a instance of.
        /// </summary>
        public virtual Model Model { get; set; }

        /// <summary>
        /// Gets a Overivew Text for an Item.
        /// </summary>
        public string ItemOverview => $"{this.Model.Prototype.Name}\n{this.Model.Manufacturer} {this.Model.ItemCode}";

        /// <summary>
        /// Gets the Name of an Item, but falls back to the Name of the Model or even the prototype.
        /// </summary>
        public string VisibleName // Returns the Model.Name if the User hasn't set the Name of the actual Item
        {
            get
            {
                if (this.Name != string.Empty)
                {
                    return this.Name;
                }
                else
                {
                    return this.Model.Name;
                }
            }
        }

        /// <summary>
        /// Gets a jpg image of the Item. Has to be loaded via <see cref="LoadImage"/>.
        /// </summary>
        public byte[] Image { get; private set; }

        /// <summary>
        /// Loads the complete set of Information associated with an item and all sub-classes.
        /// </summary>
        public virtual void LoadAdvanced()
        {
        }

        /// <summary>
        /// Tries to load an Image into the Image Property.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the state of the asynchronous operation.</returns>
        public async Task LoadImage()
        {
            using (var dataReader = await TkDatabase.ExecuteQueryAsync($"SELECT image FROM item WHERE id={this.Id};"))
            {
                try
                {
                    await dataReader.ReadAsync();
                    if (dataReader[0] == System.DBNull.Value)
                    {
                        return;
                    }

                    this.Image = (byte[])dataReader[0];
                }
                catch
                {
                }
            }
        }
    }
}