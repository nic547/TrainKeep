using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Tklib;

namespace Tklib.Db
{
    public abstract class Locomotives
    {
        public virtual ObservableCollection<Locomotive> Items { get; set; } = new ObservableCollection<Locomotive>();
        public virtual Dictionary<int, Model> Models { get; set; } = new Dictionary<int, Model>();
        public virtual Dictionary<int, Prototype> Prototypes { get; set; } = new Dictionary<int, Prototype>();
        public abstract Task Load();
    }
}
