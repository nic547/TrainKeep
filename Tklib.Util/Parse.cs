// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.
#pragma warning disable IDE0060 // Remove unused parameter
namespace Tklib.Util
{
    /// <summary>
    /// Contains extension methods to convert strings and objects to other datatypes.
    /// </summary>
    public static class Parse
    {
        /// <summary>
        /// Convert a string into a nullable short.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>A nullable short.</returns>
        public static short? ParseToShort(this string input)
        {
            short.TryParse(input, out short result);
            return input == string.Empty ? (short?)null : result;
        }

        /// <summary>
        /// Convert a object into a nullable short.
        /// </summary>
        /// <param name="input">The object to be converted.</param>
        /// <returns>A nullable short.</returns>
        public static short? ParseToShort(this object input)
        {
            return ParseToShort(input.ToString());
        }

        /// <summary>
        /// Convert a string into a nullable int.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>A nullable int.</returns>
        public static int? ParseToInt(this string input)
        {
            int.TryParse(input, out int result);
            return input == string.Empty ? (int?)null : result;
        }

        /// <summary>
        /// Convert a object into a nullable int.
        /// </summary>
        /// <param name="input">The object to be converted.</param>
        /// <returns>A nullable int.</returns>
        public static int? ParseToInt(this object input)
        {
            return ParseToInt(input.ToString());
        }
    }
}
#pragma warning restore IDE0060 // Remove unused parameter