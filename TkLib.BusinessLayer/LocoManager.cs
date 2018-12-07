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
    public class LocoManager : ManagerBase
    {

        public List<Item> List
        {
            get
            {
                using (var context = new TrainKeepContext())
                {
                    return context.Items.ToList();
                }
            }
        }

        public async Task<int> Insert(Item i)
        {
            using (var context = new TrainKeepContext())
            {
                context.Entry(i).State = EntityState.Added;
                return await context.SaveChangesAsync();
            }
        }
    }
}
