// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Tklib;

    /// <summary>
    /// Contains everything related to locomotives in the database.
    /// </summary>
    public abstract class Locomotives
    {
        /// <summary>
        /// Gets a Collection of all locomotives in the database.
        /// </summary>
        public virtual ObservableCollection<Locomotive> Items { get; internal set; } = new ObservableCollection<Locomotive>();

        /// <summary>
        /// Gets all locomotive models and their id's in the database.
        /// </summary>
        public virtual Dictionary<int, Model> Models { get; internal set; } = new Dictionary<int, Model>();

        /// <summary>
        /// Gets all locomotive prototypes and their id's in the database.
        /// </summary>
        public virtual Dictionary<int, Prototype> Prototypes { get; internal set; } = new Dictionary<int, Prototype>();

        /// <summary>
        /// Load the locomotives from the database. The Collections get updated accordingly.
        /// </summary>
        /// <returns><see cref="Task"/>representing the async operation.</returns>
        public abstract Task Load();

        /// <summary>
        /// Try and load the image of an item. The item gets updated accordingly.
        /// </summary>
        /// <param name="locomotive"><see cref="Locomotive"/> for which the image should be loaded.</param>
        /// <returns><see cref="Task"/>representing the async operation.</returns>
        public abstract Task LoadImage(Locomotive locomotive);
    }
}
