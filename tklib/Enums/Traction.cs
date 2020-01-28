// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Enums
{
    /// <summary>
    /// Contains functionality related to the type of traction a vehicle uses.
    /// </summary>
    public static class Traction
    {
        /// <summary>
        /// The types of traction as in TrainKeep.
        /// </summary>
        public enum TractionType
        {
            /// <summary>
            /// Represents a unkown type of traction
            /// </summary>
            Unspecified,

            /// <summary>
            /// Coal fired Steam engine
            /// </summary>
            SteamCoal,

            /// <summary>
            /// Oil-fired Steam engines
            /// </summary>
            SteamOil,

            /// <summary>
            /// Diesel mechanical engines
            /// </summary>
            DieselMechanical,

            /// <summary>
            /// Diesel-electric engines
            /// </summary>
            DieselElectric,

            /// <summary>
            /// Diesel-electric engines
            /// </summary>
            DieselHydraulic,

            /// <summary>
            /// Represents Propelation of a vehicle using a gas turbine
            /// </summary>
            GasTurbine,

            /// <summary>
            /// Propelation using electric energy
            /// </summary>
            Electric,

            /// <summary>
            /// Combining two different types of locomottion
            /// </summary>
            Hybrid,

            /// <summary>
            /// Represents locomotion by any other means, for example steam electric or chemical (human)
            /// </summary>
            Other,
        }

        /// <summary>
        /// Returns the <see cref="TractionType"/> that corresponds to the input. Case-insensitive, underscores get ignored.
        /// </summary>
        /// <param name="o">Object, should result in a string that fits to one of the tractionTypes.</param>
        /// <returns><see cref="TractionType"/> that corresponds to the inputed object.</returns>
        public static TractionType FromString(object o)
        {
            string s = o.ToString().ToLower();
            s = s.Replace("_", string.Empty);
            switch (s)
            {
                case "steamcoal": return TractionType.SteamCoal;
                case "steamoil": return TractionType.SteamOil;
                case "dieselmechanical": return TractionType.DieselMechanical;
                case "dieselelectric": return TractionType.DieselElectric;
                case "dieselhydraulic": return TractionType.DieselHydraulic;
                case "gasturbine": return TractionType.GasTurbine;
                case "electric": return TractionType.Electric;
                case "hybrid": return TractionType.Hybrid;
                default: return TractionType.Unspecified;
            }
        }
    }
}
