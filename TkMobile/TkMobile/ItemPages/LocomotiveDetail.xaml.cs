using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TkLib.BusinessLayer;
using TkLib.Dal.Entities;

namespace TkMobile.ItemPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveDetail : TabbedPage
    {
        public Item Item { get; set; }
        public LocomotiveDetail (Item item)
        {
            InitializeComponent();
            Item = item;
        }

        protected override void OnAppearing()
        {
            
        }
    }
}