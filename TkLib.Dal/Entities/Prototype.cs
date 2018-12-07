using System;
using System.Collections.Generic;
using System.Text;

namespace TkLib.Dal.Entities
{
    public class Prototype
    {
        public int PrototypeId { get; set; }
        public string Name { get; set; }

        public List<ItemModel> models { get; set; }
    }
}
