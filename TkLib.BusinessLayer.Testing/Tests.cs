using System;
using Xunit;

using TkLib.BusinessLayer;
using TkLib.Dal.Entities;
using TkLib.Dal;

namespace TkLib.BusinessLayer.Testing
{
    public class Tests
    {
        [Fact]
        public async void LocomotiveInsertTest()
        {
            var manager = new LocoManager();
            using (var context = new TrainKeepContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            var loco = new Item(Item.ItemType.Locomotive)
            {
                Name = "X-Rail Re 620",
                Price = 32000
            };

            await manager.Insert(loco);

        }
    }
}
