// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Pgsql
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Tklib;

    /// <inheritdoc/>
    public class PgsqlItems : Items
    {
        private readonly PgsqlDatabase pgDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="PgsqlItems"/> class.
        /// </summary>
        /// <param name="vehicleType">The type of vehicle this object shall contain.</param>
        /// <param name="database">The database.</param>
        public PgsqlItems(string vehicleType, PgsqlDatabase database)
            : base(vehicleType, database)
        {
            pgDatabase = database;
        }

        public override void Create(Item item)
        {
            throw new NotImplementedException();
        }

        public override void Create(Model model)
        {
            throw new NotImplementedException();
        }

        public override void Create(Prototype prototype)
        {
            var query = $"INSERT INTO proto_class (name, vehicle_type, proto_weight, proto_speed, engine_tractive_effort, engine_power)" +
                $"VALUES ('{prototype.Name}', '{VehicleType}', {prototype.Weight}, {prototype.Speed}, {prototype.TractiveEffort}, {prototype.Power})" +
                $"RETURNING id";

            var dr = pgDatabase.ExecuteQuery(query);
            dr.Read();
            prototype.Id = (int)dr[0];
        }

        /// <inheritdoc/>
        public override async Task Load()
        {
            var start = DateTime.Now;
            Collection.Clear();
            var dr = await pgDatabase.ExecuteQueryAsync("SELECT item.id,item.name,model_item.id,model_item.name,model_item.item_code,proto_class.id,proto_class.name,manufacturer.name FROM item " +
                                                "LEFT JOIN model_item ON item.model_item = model_item.id " +
                                                "LEFT JOIN proto_class ON model_item.proto_class = proto_class.id " +
                                                "LEFT JOIN manufacturer ON model_item.manufacturer = manufacturer.id " +
                                                "WHERE proto_class.vehicle_type = '" + VehicleType + "'" +
                                                "ORDER BY COALESCE(item.name,model_item.name)");

            while (dr.Read())
            {
                if (!Prototypes.TryGetValue((int)dr[5], out Prototype prototype))
                {
                    prototype = new Prototype()
                    {
                        Id = (int)dr[5],
                        Name = dr[6].ToString(),
                    };
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
                        Prototype = prototype,
                    };
                    Models.Add(model.Id, model);
                }

                Collection.Add(new Item()
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Model = model,
                });
            }

            dr.Close();
            Debug.WriteLine((DateTime.Now - start).TotalMilliseconds + $"ms until all {VehicleType} were loaded");
        }

        /// <inheritdoc/>
        public override async Task LoadImage(Item item)
        {
            using var dataReader = await pgDatabase.ExecuteQueryAsync($"SELECT image FROM item WHERE id={item.Id};");
            try
            {
                await dataReader.ReadAsync();
                if (dataReader[0] == DBNull.Value)
                {
                    return;
                }

                item.Image = (byte[])dataReader[0];
            }
            catch
            {
            }
        }

        public override void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
