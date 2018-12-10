using System;
using Xunit;

using TkLib.BusinessLayer;
using TkLib.Dal.Entities;
using TkLib.Dal;

namespace TkLib.BusinessLayer.Testing
{
    public class LocomotiveTest: TestBase
    {
        [Fact]
        public async void InsertTests()
        {
            var manager = new ItemManager();


            var manufacturer = new Manufacturer("Märklin");
            //await manager.Insert(manufacturer);

            
            var model = new ItemModel()
            {
                Name = "Elektrolokomotive Reihe 620",
                Code = "37326",
                Manufacturer = manufacturer,
                ReportingMark = "088-5",
                Livery = "Xrail-Cargo",
                Prototype = new Prototype(Prototype.PrototypeType.Locomotive)
                {
                    Name = "SBB Re 6/6"
                }
            };
            //await manager.Insert(model);

            var loco = new Item()
            {
                Name = "X-Rail Re 620 Linthal",
                Price = 320_00,
                Model = model,
            };

            await manager.Insert(loco);

            Assert.NotEmpty(manager.List);
        }
    }
}
