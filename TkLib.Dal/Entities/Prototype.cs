using System;
using System.Collections.Generic;
using System.Text;

namespace TkLib.Dal.Entities
{
    public class Prototype
    {
        public int PrototypeId { get; set; }
        public string Name { get; set; }

        public enum PrototypeType {Locomotive,MultipleUnit,Wagon}
        public PrototypeType Type { get; set; }

        public List<ItemModel> Models { get; set; }

        public Prototype(PrototypeType type)
        {
            Type = type;
        }
    }
}
