using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Tklib
{
    public class Prototype
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PrototypeAdvanced? Advanced { get; set; }

        public Prototype(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public async void LoadAdvanced()
        {
            /*
            Advanced = new PrototypeAdvanced();

            var ProtoTask = Task.Run(async () => {
                var dataReader = await TkDatabase.ExecuteQueryAsync($"SELECT proto_height, proto_width, proto_lenght_over_buffers, proto_weight, axle_formula, axle_amount FROM proto_class WHERE id={Id}");
                await dataReader.ReadAsync();
                
            });

           await ProtoTask; */
        }
    }
    public class PrototypeAdvanced
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Lenght { get; set; }
        public int Weight { get; set; }
        public string? AxleFormula { get; set; }
        public short AxleAmount { get; set; }
        
        public bool IsPowered { get; set; }
        public short TractiveEffort { get; set; }
        public short PowerContinus { get; set; }
        public short PowerShort { get; set; }
        public short AxlePoweredAmount { get; set; }
        public Enums.TractionType.Type? TractionType { get; set; }

        public bool IsLoadable { get; set; }
        public bool IsCoach { get; set; }
        public short Capacity { get; set; }

    }
}
