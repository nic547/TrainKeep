// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// One setting for a database connection (ex. 'hostname=127.0.0.0').
    /// </summary>
    public class SingleDatabaseSetting
    {
        private string name;

        /// <summary>
        /// Gets or Sets the name of a setting as used for the connection string. Ex. "Hostname" or "Password".
        /// </summary>
        public string Setting { get; set; }

        /// <summary>
        /// Gets or sets the name of a setting as shown to the user. If none is set, <see cref="Setting"/> is returned instead.
        /// </summary>
        public string Name { get => name ?? Setting; set => name = value; }

        /// <summary>
        /// Gets or Sets the value of a setting. Ex. "127.0.0.0" or "Hunter2".
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets the description of a setting shown to a user. Might be also be usefull for documentation, even if setting is not displayed to user.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this setting should appear as a setting or if it's always used with it's default value.
        /// This allows that all settings are definied in one place, instead of having to seperatly declare "user facing settings" and
        /// "hardcoded settings".
        /// </summary>
        public bool DisplayToUser { get; set; }

        /// <summary>
        /// Returns the Option as a ConnectionString.
        /// </summary>
        /// <returns>The connections string.</returns>
        public string ToConnectionString()
        {
            return $"{Setting}={Value};";
        }
    }
}
