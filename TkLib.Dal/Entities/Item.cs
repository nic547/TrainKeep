using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TkLib.Dal.Entities
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public enum ItemType { Locomotive, Wagon, MultipleUnit }
		public ItemType Type { get; set; }

        public int? ModelId { get; set; }
		public ItemModel Model { get; set; }


		public Item (ItemType type)
        {
            Type = type;
        }
    }
}
