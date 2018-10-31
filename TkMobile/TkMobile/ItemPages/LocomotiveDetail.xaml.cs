using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveDetail : TabbedPage
    {
        public tklib.Locomotive Item { get; set; }
        public LocomotiveDetail (tklib.Locomotive item)
        {
            InitializeComponent();
            Item = item;
        }

        protected override void OnAppearing()
        {
            
        }
    }
}