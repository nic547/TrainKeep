// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Pgsql.Tests
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="GetLocomotives"/>.
    /// </summary>
    public static class TestData
    {
        /// <summary>
        /// Gets a list of locomotives (test data).
        /// </summary>
        /// <returns>A list of items.</returns>
        public static List<Item> GetLocomotives()
        {
            var re460 = new Prototype()
            {
                Name = "Re 460",
                Power = 6100,
                Speed = 200,
                Weight = 84000,
                TractiveEffort = 300,
            };

            var traxx_f140_ac1 = new Prototype()
            {
                Name = "Traxx F140 AC1",
                Power = 5600,
                Speed = 140,
                TractiveEffort = 300,
            };

            var traxx_f140_ac2 = new Prototype()
            {
                Name = "Traxx F140 AC2",
                Power = 5600,
                Speed = 140,
                TractiveEffort = 300,
            };

            var traxx_f140_ac3 = new Prototype()
            {
                Name = "Traxx F140 AC3",
                Power = 5600,
                Speed = 140,
                TractiveEffort = 300,
            };

            var vectron_ms = new Prototype()
            {
                Name = "Vectron MS",
                Power = 6400,
                Speed = 140,
                TractiveEffort = 300,
            };

            var re460_refit = new Model()
            {
                Name = "Re 460 Helvetia",
                ItemCode = "3600",
                Manufacturer = "Swiss Classic Trains",
                Prototype = re460,
            };

            var re460_knie = new Model()
            {
                Name = "Re 460 Circus Knie",
                ItemCode = "3601",
                Manufacturer = "Swiss Classic Trains",
                Prototype = re460,
            };

            var re460_polmengo = new Model()
            {
                Name = "Re 460 Polmengo",
                ItemCode = "3602",
                Manufacturer = "Swiss CLassic Trains",
                Prototype = re460,
            };

            var re482_001 = new Model()
            {
                Name = "Re 482 001 (Cargo)",
                ItemCode = "42000",
                Manufacturer = "Modern Trains",
                Prototype = traxx_f140_ac1,
            };

            var re482_022 = new Model()
            {
                Name = "Re 482 022 (Alpäzähmer)",
                ItemCode = "42001",
                Manufacturer = "Modern Trains",
                Prototype = traxx_f140_ac1,
            };

            var re482_038 = new Model()
            {
                Name = "Re 482 038 (Cargo)",
                ItemCode = "43001",
                Manufacturer = "Modern Trains",
                Prototype = traxx_f140_ac2,
            };

            return new List<Item>()
            {
                new Item()
                {
                    Model = re460_polmengo,
                },
                new Item()
                {
                    Model = re460_refit,
                },
                new Item()
                {
                    Model = re460_knie,
                },
                new Item()
                {
                    Model = re482_001,
                },
                new Item()
                {
                    Model = re482_022,
                },
                new Item()
                {
                    Model = re482_038,
                },
            };
        }
    }
}
