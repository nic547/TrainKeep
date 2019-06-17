// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Pgsql
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public class PgsqlLocomotives : Locomotives
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PgsqlLocomotives"/> class.
        /// </summary>
        /// <param name="db">Database.</param>
        public PgsqlLocomotives(PgsqlDatabase db)
        {
            this.PgsqlDb = db;
        }

        private PgsqlDatabase PgsqlDb { get; }

        /// <inheritdoc/>
        public override async Task Load()
        {
            var start = DateTime.Now;
            this.Items.Clear();
            var dr = await this.PgsqlDb.ExecuteQueryAsync("SELECT item.id,item.name,model_item.id,model_item.name,model_item.item_code,proto_class.id,proto_class.name,manufacturer.name FROM item " +
                                                "LEFT JOIN model_item ON item.model_item = model_item.id " +
                                                "LEFT JOIN proto_class ON model_item.proto_class = proto_class.id " +
                                                "LEFT JOIN manufacturer ON model_item.manufacturer = manufacturer.id " +
                                                "WHERE proto_class.species = 'locomotive'" +
                                                "ORDER BY COALESCE(item.name,model_item.name)");

            while (dr.Read())
            {
                if (!this.Prototypes.TryGetValue((int)dr[5], out Prototype prototype))
                {
                    prototype = new Prototype((int)dr[5], dr[6].ToString());
                    this.Prototypes.Add(prototype.Id, prototype);
                }

                if (!this.Models.TryGetValue((int)dr[2], out Model model))
                {
                    model = new Model()
                    {
                        Id = (int)dr[2],
                        Name = dr[3].ToString(),
                        Manufacturer = dr[7].ToString(),
                        ItemCode = dr[4].ToString(),
                        Prototype = prototype,
                    };
                    this.Models.Add(model.Id, model);
                }

                this.Items.Add(new Locomotive()
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Model = model,
                });
            }

            dr.Close();
            Debug.WriteLine((DateTime.Now - start).TotalMilliseconds + "ms until all locomotives were loaded");
        }

        /// <inheritdoc/>
        public override async Task LoadImage(Locomotive locomotive)
        {
            using (var dataReader = await this.PgsqlDb.ExecuteQueryAsync($"SELECT image FROM item WHERE id={locomotive.Id};"))
            {
                try
                {
                    await dataReader.ReadAsync();
                    if (dataReader[0] == System.DBNull.Value)
                    {
                        return;
                    }

                    locomotive.Image = (byte[])dataReader[0];
                }
                catch
                {
                }
            }
        }
    }
}
