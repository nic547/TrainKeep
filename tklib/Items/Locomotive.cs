using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tklib
{
    public class Locomotive : Item
    {

        public override void LoadAdvanced()
        {
            throw new NotImplementedException();
        }
    }

    public class LocomotiveModel : ItemModel
    {

    }

    public class LocomotivePrototype : Prototype
    {

    }

    public static class Locomotives
    {
        public static List<Locomotive> items = new List<Locomotive>();

        public static async Task Load()
        {
            var dr = await TkDatabase.ExecuteQueryAsync("SELECT item.id,item.name,model_item.id,model_item.name,model_item.item_code,proto_class.id,proto_class.name,manufacturer.name FROM item " +
                                                "LEFT JOIN model_item ON item.model_item = model_item.id " +
                                                "LEFT JOIN proto_class ON model_item.proto_class = proto_class.id " +
                                                "LEFT JOIN manufacturer ON model_item.manufacturer = manufacturer.id " +
                                                "WHERE proto_class.species = 'locomotive'" +
                                                "ORDER BY COALESCE(item.name,model_item.name)");

            while (dr.Read())
            {
                items.Add(new Locomotive()
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Model = new LocomotiveModel()
                    {
                        Id = (int)dr[2],
                        Name = dr[3].ToString(),
                        Manufacturer = dr[7].ToString(),
                        ItemCode = dr[4].ToString(),
                        Prototype = new LocomotivePrototype()
                        {
                            Id = (int)dr[5],
                            Name = dr[6].ToString()

                        }
                    }
                });
            }
            dr.Close();
        }
    }

}