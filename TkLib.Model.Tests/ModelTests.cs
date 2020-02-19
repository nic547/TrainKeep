// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkLib.Model.Tests
{
    using NUnit.Framework;
    using Tklib;

    /// <summary>
    /// Tests related to <see cref="Model"/>.
    /// </summary>
    public class ModelTests
    {
        /// <summary>
        /// Assert that two equal models are considered equal.
        /// </summary>
        [Test]
        public void TestValueEquality()
        {
            Assert.That(GetModelOne().Equals(GetModelOne()));
        }

        /// <summary>
        /// Test if the hash code of two equal objects are equal.
        /// </summary>
        [Test]
        public void TestHashcodeEquality()
        {
            Assert.That(GetModelOne().GetHashCode() == GetModelOne().GetHashCode());
        }

        /// <summary>
        /// Test that equal model with different prototypes are not considered equal.
        /// </summary>
        [Test]
        public void TestUnequalPrototype()
        {
            var model = GetModelOne();
            model.Name = "TRAXX F140 AC3";

            Assert.IsFalse(model.Equals(GetModelOne()));
        }

        /// <summary>
        /// Test that two different models with the same prototype are not considered equal.
        /// </summary>
        public void TestUnequalModel()
        {
            Assert.IsFalse(GetModelOne().Equals(GetModelTwo()));
        }

        private Model GetModelOne()
        {
            return new Model()
            {
                Id = 1337,
                Name = "Rem 487 001",
                ItemCode = "87000",
                Manufacturer = "Scout Constructs",
                Prototype = new Prototype()
                {
                    Id = 1,
                    Name = "Traxx F140 AC3",
                    Power = 5600,
                    Speed = 140,
                    TractiveEffort = 300,
                },
            };
        }

        private Model GetModelTwo()
        {
            return new Model()
            {
                Id = 94932,
                Name = "BR 187 (Railpool/BLS)",
                ItemCode = "87004",
                Manufacturer = "Scout Constructs",
                Prototype = new Prototype()
                {
                    Id = 1,
                    Name = "Traxx F140 AC3",
                    Power = 5600,
                    Speed = 140,
                    TractiveEffort = 300,
                },
            };
        }
    }
}
