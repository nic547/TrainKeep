using System;
using System.Collections.Generic;
using System.Text;

namespace TkLib.Dal.Entities
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }

        public List<ItemModel> Models { get; set; }

        public Manufacturer(string name)
        {
            Name = name;
        }
    }
}
