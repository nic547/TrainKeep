using Xunit;

using TkLib.Dal.Entities;

namespace TkLib.Dal.Testing
{
    public class DisplayStringsTest
    {
        [Fact]
        public void VisibleNameTest()
        {
            var protoOnly = new Item(Item.ItemType.Locomotive)
            {
                Model = new ItemModel()
                {
                    Prototype = new Prototype()
                    {
                        Name = "Re 460"
                    }
                }
            };
            Assert.Equal("Re 460",protoOnly.VisibleName);

            var ModelNameLoco = new Item(Item.ItemType.Locomotive)
            {
                Model = new ItemModel()
                {
                    Name = "Re 460 Helvetia",
                    Prototype = new Prototype()
                    {
                        Name = "Re 460"
                    }
                }
            };
            Assert.Equal("Re 460 Helvetia", ModelNameLoco.VisibleName);
       
            var ActualName = new Item(Item.ItemType.Locomotive)
            {
                Name = "Biene Maja",
                Model = new ItemModel()
                {
                    Name = "Rem 487",
                    Prototype = new Prototype()
                    {
                        Name = "TRAXX F160 AC3 LM"
                    }
                }
            };
            Assert.Equal("Biene Maja", ActualName.VisibleName);

            var NoName = new Item(Item.ItemType.Locomotive);
            Assert.Equal("", NoName.VisibleName);
        }


        [Fact]
        public void OverviewTest()
        {
            var protoOnly = new Item(Item.ItemType.Locomotive)
            {
                Name = "Biene Maja",
                Model = new ItemModel()
                {
                    Name = "Rem 487",
                    Code = "XXXXX",
                    Manufacturer = new Manufacturer("Märklin"),
                    Prototype = new Prototype()
                    {
                        Name = "TRAXX F160 AC3 LM"
                    }
                }
            };
            Assert.Equal("TRAXX F160 AC3 LM\nMärklin XXXXX", protoOnly.ItemOVerview);
        }
    }
}
