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
	public partial class LocomotiveOverviewTile : ContentPage
    {
		public LocomotiveOverviewTile ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            
        }
    }
}