// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Tklib;

    /// <summary>
    /// Contains everything related to one vehicle type in the database.
    /// </summary>
    public abstract class Items
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Items"/> class.
        /// </summary>
        /// <param name="vehicleType">The type of vehicle this object is responsible for.</param>
        /// <param name="database">The database.</param>
        public Items(string vehicleType, Database database)
        {
            VehicleType = vehicleType;
            Database = database;
        }

        /// <summary>
        /// Gets a collection of all items in the database with the vehicle type specified.
        /// </summary>
        public virtual ObservableCollection<Item> Collection { get; internal set; } = new ObservableCollection<Item>();

        /// <summary>
        /// Gets all models and their id's in the database.
        /// </summary>
        public virtual Dictionary<int, Model> Models { get; internal set; } = new Dictionary<int, Model>();

        /// <summary>
        /// Gets all prototypes and their id's in the database.
        /// </summary>
        public virtual Dictionary<int, Prototype> Prototypes { get; internal set; } = new Dictionary<int, Prototype>();

        /// <summary>
        /// Gets vehicle type used.
        /// </summary>
        protected string VehicleType { get; }

        /// <summary>
        /// Gets the database used.
        /// </summary>
        protected Database Database { get; }

        /// <summary>
        /// Load the locomotives from the database. The Collections get updated accordingly.
        /// </summary>
        /// <returns><see cref="Task"/>representing the async operation.</returns>
        public abstract Task Load();

        /// <summary>
        /// Try and load the image of an item. The item gets updated accordingly.
        /// </summary>
        /// <param name="item"><see cref="Item"/> for which the image should be loaded.</param>
        /// <returns><see cref="Task"/>representing the async operation.</returns>
        public abstract Task LoadImage(Item item);

        /// <summary>
        /// Insert a new Item into the Database.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> to be inserted.</param>
        /// /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public abstract Task Save(Item item);

        /// <summary>
        /// Insert a new Model into the Database.
        /// </summary>
        /// <param name="model">The <see cref="Model"/> to be inserted.</param>
        /// /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public abstract Task Save(Model model);

        /// <summary>
        /// Insert a new Prototype into the Database.
        /// </summary>
        /// <param name="prototype">The <see cref="Prototype"/> to be inserted.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public abstract Task Save(Prototype prototype);
    }
}
