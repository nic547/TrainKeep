// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkLib.Model.Tests
{
    using NUnit.Framework;
    using Tklib;

    /// <summary>
    /// Tests related to <see cref="Prototype"/>.
    /// </summary>
    public class PrototypeTests
    {
        /// <summary>
        /// Test for equality of two prototypes identical values.
        /// </summary>
        [Test]
        public void TestValueEquality()
        {
            var proto1 = new Prototype()
            {
                Name = "Re 460",
                Id = 0,
                Weight = 84000,
                Speed = 200,
                Power = 6100,
                TractiveEffort = 300,
            };

            var proto2 = new Prototype()
            {
                Name = "Re 460",
                Id = 0,
                Weight = 84000,
                Speed = 200,
                Power = 6100,
                TractiveEffort = 300,
            };

            Assert.That(proto1.Equals(proto2));
        }

        /// <summary>
        /// Test two prototypes that are not equal.
        /// </summary>
        [Test]
        public void TestNonEquality()
        {
            var proto1 = new Prototype()
            {
                Name = "Re 460",
                Id = 0,
                Weight = 84000,
                Speed = 200,
                Power = 6100,
                TractiveEffort = 300,
            };

            var proto2 = new Prototype()
            {
                Name = "Vectron MS",
                Id = 0,
                Weight = null,
                Speed = 200,
                Power = 6400,
                TractiveEffort = 300,
            };
            Assert.That(!proto1.Equals(proto2));
        }

        /// <summary>
        /// Test equality two prototypes that reference the same prototype.
        /// </summary>
        [Test]
        public void TestEqualityOfReference()
        {
            var proto1 = new Prototype();
            var proto2 = proto1;
            Assert.That(proto2.Equals(proto1));
        }

        /// <summary>
        /// Tests GetHashCode() for a bunch of prototypes.
        /// </summary>
        [Test]
        public void TestHashCode()
        {
            var proto1 = new Prototype()
            {
                Name = "Re 460",
                Id = 0,
                Weight = 84000,
                Speed = 200,
                Power = 6100,
                TractiveEffort = 300,
            };

            var proto2 = new Prototype()
            {
                Name = "Vectron MS",
                Id = 0,
                Weight = null,
                Speed = 200,
                Power = 6400,
                TractiveEffort = 300,
            };

            var proto3 = new Prototype()
            {
                Name = "Vectron MS",
                Id = 0,
                Weight = null,
                Speed = 200,
                Power = 6400,
                TractiveEffort = 300,
            };

            var proto1ref = proto1;
            var proto2ref = proto2;
            var proto3ref = proto3;

            Assert.That(proto1.GetHashCode() == proto1ref.GetHashCode());
            Assert.That(proto1.GetHashCode() != proto2.GetHashCode());
            Assert.That(proto1ref.GetHashCode() != proto2ref.GetHashCode());
            Assert.That(proto2.GetHashCode() == proto3.GetHashCode());
            Assert.That(proto2.GetHashCode() == proto3ref.GetHashCode());
            Assert.That(proto2ref.GetHashCode() == proto3ref.GetHashCode());
        }

        /// <summary>
        /// Tests the Clone() functionality.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            var proto1 = new Prototype()
            {
                Id = int.MaxValue,
                Name = "Re 620",
                Weight = null,
                Speed = 140,
                Power = 7920,
            };

            var copy = proto1.Clone();
            Assert.That(copy.Equals(proto1));
            Assert.That(!ReferenceEquals(copy, proto1));
        }
    }
}