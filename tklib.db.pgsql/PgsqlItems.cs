// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Pgsql
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Tklib;
    using Tklib.Util;

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

        /// <inheritdoc/>
        public override async void Save(Item item)
        {
            Save(item.Model);

            if (item.Id == 0)
            {
                var query = $"INSERT INTO item (name, model_item, notes, dcc)" +
                    $"VALUES ('{item.Name}',{item.Model.Id},'{item.Notes}',{item.Dcc})" +
                    $"RETURNING id";
                var dr = await pgDatabase.ExecuteQueryAsync(query);
                dr.Read();
                item.Id = (int)dr[0];
                Collection.Add(item);
            }
            else
            {
                var query = $"UPDATE item " +
                    $"SET name = '{item.Name}' " +
                    $"notes = '{item.Notes}' " +
                    $"dcc = {item.Dcc} " +
                    $"model_item = {item.Model.Id} " +
                    $"WHERE id ={item.Id}";

                Collection.Where(x => x.Id == item.Id).Single().SetValuesTo(item);

                _ = pgDatabase.ExecuteQueryAsync(query);
            }
        }

        /// <inheritdoc/>
        public override async void Save(Model model)
        {
            Save(model.Prototype);

            if (model.Id == 0)
            {
                var query = $"INSERT INTO model_item (name, proto_class, item_code)" +
                    $"VALUES ('{model.Name}',{model.Prototype.Id},'{model.ItemCode}')" +
                    $"RETURNING id";
                var dr = await pgDatabase.ExecuteQueryAsync(query);
                dr.Read();
                model.Id = (int)dr[0];
                Models.Add(model.Id, model);
            }
            else
            {
                var query = $"UPDATE model_item " +
                $"SET name = '{model.Name}', " +
                $"item_code = '{model.ItemCode}', " +
                $"proto_class = {model.Prototype.Id} " +
                $"WHERE id={model.Id}";

                _ = pgDatabase.ExecuteQueryAsync(query);
            }
        }

        /// <inheritdoc/>
        public override async void Save(Prototype prototype)
        {
            if (prototype.Id == 0)
            {
                var query = $"INSERT INTO proto_class (name, vehicle_type, proto_weight, proto_speed, engine_tractive_effort, engine_power)" +
                    $"VALUES ('{prototype.Name}', '{VehicleType}', {prototype.Weight}, {prototype.Speed}, {prototype.TractiveEffort}, {prototype.Power})" +
                    $"RETURNING id";

                var dr = await pgDatabase.ExecuteQueryAsync(query);
                dr.Read();
                prototype.Id = (int)dr[0];
                Prototypes.Add(prototype.Id, prototype);
            }
            else
            {
                var query =
                    $"UPDATE proto_class " +
                    $"SET name = '{prototype.Name}', " +
                    $"proto_speed = {prototype.Speed}, " +
                    $"proto_weight = {prototype.Weight}, " +
                    $"engine_tractive_effort = {prototype.TractiveEffort}, " +
                    $"engine_power = {prototype.Power} " +
                    $"WHERE id = {prototype.Id} ";

                _ = pgDatabase.ExecuteQueryAsync(query);
            }
        }

        /// <inheritdoc/>
        public override async Task Load()
        {
            var start = DateTime.Now;
            Collection.Clear();
            Models.Clear();
            Prototypes.Clear();
            var dr = await pgDatabase.ExecuteQueryAsync("SELECT item.id,item.name,item.dcc,model_item.id,model_item.name,model_item.item_code,manufacturer.name,proto_class.id,proto_class.name,proto_weight,proto_speed,engine_tractive_effort,engine_power FROM item " +
                                                "RIGHT JOIN model_item ON item.model_item = model_item.id " +
                                                "RIGHT JOIN proto_class ON model_item.proto_class = proto_class.id " +
                                                "LEFT JOIN manufacturer ON model_item.manufacturer = manufacturer.id " +
                                                "WHERE proto_class.vehicle_type = '" + VehicleType + "'");

            while (dr.Read())
            {
                if (!Prototypes.TryGetValue((int)dr[7], out Prototype prototype))
                {
                    prototype = new Prototype()
                    {
                        Id = (int)dr[7],
                        Name = dr[8].ToString(),
                        Weight = dr[9].ParseToInt(),
                        Speed = dr[10].ParseToShort(),
                        TractiveEffort = dr[11].ParseToShort(),
                        Power = dr[12].ParseToShort(),
                    };
                    Prototypes.Add(prototype.Id, prototype);
                }

                if (dr[3] == DBNull.Value)
                {
                    continue;
                }

                if (!Models.TryGetValue((int)dr[3], out Model model))
                {
                    model = new Model()
                    {
                        Id = (int)dr[3],
                        Name = dr[4].ToString(),
                        Manufacturer = dr[6].ToString(),
                        ItemCode = dr[5].ToString(),
                        Prototype = prototype,
                    };
                    Models.Add(model.Id, model);
                }

                if (dr[0] != DBNull.Value)
                {
                    Collection.Add(new Item()
                    {
                        Id = (int)dr[0],
                        Name = dr[1].ToString(),
                        Dcc = dr[2].ParseToShort(),
                        Model = model,
                    });
                }
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
    }
}
