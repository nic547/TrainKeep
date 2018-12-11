using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TkLib.Dal.Entities
{
    public class ItemModel
    {
        public int ItemModelId { get; set; }
        public string Name { get; set; }

        public List<Item> Items { get; set; }
        public int PrototypeId { get; set; }
        public Prototype Prototype { get; set; }

        public string Code { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string ReportingMark { get; set; }
        public string Livery { get; set; }

        // Xamarin can't (yet) do multibinding, overriding toString is a nice way around it
        public override string ToString()
        {
            return $"{Name} - {Manufacturer.Name}: {Code}";
        }
    }
}
