using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace tklib
{
    public class Locomotive : Item
    {

    }

    public class Locomotives
    {
        public ObservableCollection<Locomotive> Items { get; set; } = new ObservableCollection<Locomotive>();
        public Dictionary<int, Model> Models { get; set; } = new Dictionary<int, Model>();
        public Dictionary<int, Prototype> Prototypes { get; set; } = new Dictionary<int, Prototype>();

        public async Task Load()
        {
            var start = DateTime.Now;
            Items.Clear();
            var dr = await TkDatabase.ExecuteQueryAsync("SELECT item.id,item.name,model_item.id,model_item.name,model_item.item_code,proto_class.id,proto_class.name,manufacturer.name FROM item " +
                                                "LEFT JOIN model_item ON item.model_item = model_item.id " +
                                                "LEFT JOIN proto_class ON model_item.proto_class = proto_class.id " +
                                                "LEFT JOIN manufacturer ON model_item.manufacturer = manufacturer.id " +
                                                "WHERE proto_class.species = 'locomotive'" +
                                                "ORDER BY COALESCE(item.name,model_item.name)");

            while (dr.Read())
            {

                if (!Prototypes.TryGetValue((int)dr[5], out Prototype prototype))
                {
                    prototype = new Prototype((int)dr[5], dr[6].ToString());
                    Prototypes.Add(prototype.Id, prototype);
                }

                if (!Models.TryGetValue((int)dr[2], out Model model))
                {
                    model = new Model()
                    {
                        Id = (int)dr[2],
                        Name = dr[3].ToString(),
                        Manufacturer = dr[7].ToString(),
                        ItemCode = dr[4].ToString(),
                        Prototype = prototype
                    };
                    Models.Add(model.Id, model);
                }

                Items.Add(new Locomotive()
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Model = model
                });

            }
            dr.Close();
            Debug.WriteLine((DateTime.Now - start).TotalMilliseconds + "ms until all locomotives were loaded");
        }
    }

}