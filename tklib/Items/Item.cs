using System;
using System.Collections.Generic;
using System.Text;

namespace tklib
{
    abstract public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public Model Model { get; set; }

        public abstract void LoadAdvanced();
        public string ItemOverview => $"{Model.Prototype.Name}\n{Model.Manufacturer} {Model.ItemCode}";
        public string VisibleName //Returns the Model.Name if the User hasn't set the Name of the actual Item
        {
            get
            {
                if (Name != "") { return Name; }
                else { return Model.Name; }
            }
        }
    }


    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ItemCode { get; set; }

        virtual public Prototype Prototype { get; set; }

        public override string ToString() => $"{Manufacturer} {ItemCode}: {Name}";
            }

    public class Prototype
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Prototype(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }

    class ProtoLoadable
    {

    }

    class ProtoPowered
    {

    }
}