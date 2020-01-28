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
    /// Contains all further information that is not found in <see cref="Prototype"/>.
    /// </summary>
    public class PrototypeAdvanced
    {
        /// <summary>
        /// Gets or sets the height of the prototype in m.
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the width of the prototype in m.
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// Gets or sets the lenght of the prototype in m.
        /// </summary>
        public decimal Lenght { get; set; }

        /// <summary>
        /// Gets or sets the weight of the prototype in kg.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the axle arrangements of the prototype, suggested format is UIC.
        /// </summary>
        public string? AxleArrangements { get; set; }

        /// <summary>
        /// Gets or sets the amount of axles.
        /// </summary>
        public short AxleAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the prototype is self powered.
        /// </summary>
        public bool IsPowered { get; set; }

        /// <summary>
        /// Gets or sets the tractive effor of the prototype in kN.
        /// </summary>
        public short TractiveEffort { get; set; }

        /// <summary>
        /// Gets or sets the continus power output of the prototype in kW.
        /// </summary>
        public short PowerContinus { get; set; }

        /// <summary>
        /// Gets or sets the short term power output of the prototype in kW.
        /// </summary>
        public short PowerShort { get; set; }

        /// <summary>
        /// Gets or sets the ammount of powered axles.
        /// </summary>
        public short AxlePoweredAmount { get; set; }

        /// <summary>
        /// Gets or sets <see cref="TractionType"/>.
        /// </summary>
        public Enums.Traction.TractionType? TractionType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the protype is able to carry a load.
        /// </summary>
        public bool IsLoadable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the prototype is a passenger coach.
        /// </summary>
        public bool IsCoach { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the prototype. Assumed to be pax for coaches, m^3 for freight cars.
        /// </summary>
        public short Capacity { get; set; }
    }
}
