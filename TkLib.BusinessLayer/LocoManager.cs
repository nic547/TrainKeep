using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TkLib.Dal;
using TkLib.Dal.Entities;

namespace TkLib.BusinessLayer
{
    public class ItemManager : ManagerBase
    {

        public List<Item> List
        {
            get
            {
                using (var context = new TrainKeepContext())
                {
                    return context.Items
                        .Include(Item => Item.Model)
                            .ThenInclude(ItemModel => ItemModel.Manufacturer)
                        .Include(Item => Item.Model)
                            .ThenInclude(ItemModel => ItemModel.Prototype)
                        .ToList();
                }
            }
        }

        public async Task Insert(Item i)
        {
            using (var context = new TrainKeepContext())
            {
                await context.Items.AddAsync(i);
                await context.SaveChangesAsync();
            }
        }
    }
}
