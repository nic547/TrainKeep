// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Enums
{
    public static class TractionType
    {
        public enum Type
        {
            Unspecified,
            SteamCoal,
            SteamOil,
            DieselMechanical,
            DieselElectric,
            DieselHydraulic,
            GasTurbine,
            Electric,
            Hybrid,
            Other }

        public static Type FromString(object o)
        {
            string s = o.ToString().ToLower();
            s = s.Replace("_", string.Empty);
            switch (s)
            {
                case "steamcoal": return Type.SteamCoal;
                case "steamoil": return Type.SteamOil;
                case "dieselmechanical": return Type.DieselMechanical;
                case "dieselelectric": return Type.DieselElectric;
                case "dieselhydraulic": return Type.DieselHydraulic;
                case "gasturbine": return Type.GasTurbine;
                case "Electric": return Type.Electric;
                case "Hybrid": return Type.Hybrid;
                default: return Type.Unspecified;
            }
        }
    }


}
