using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tklib;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemOverviews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocomotiveOverviewList : ContentPage
	{
		public LocomotiveOverviewList ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            await Locomotives.Load();
            LocoList.ItemsSource = Locomotives.items;
        }
	}
}