using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TkLib.Dal.Entities
{
    public class Item
    {   
        #nullable enable
        public int ItemID { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }

        public int? ModelId { get; set; }
		public ItemModel? Model { get; set; }

        // Strings for Display in the UI
        
        [NotMapped]
        public string VisibleName => Name ?? Model?.Name ?? Model?.Prototype?.Name ?? "";
        [NotMapped]
        public string ItemOverview => $"{Model?.Prototype.Name}\n{Model?.Manufacturer.Name} {Model?.Code}";

    }
}
