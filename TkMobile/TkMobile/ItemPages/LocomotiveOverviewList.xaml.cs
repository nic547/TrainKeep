using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using tklib;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemPages
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
            var start = DateTime.Now;
            await Locomotives.Load();
            LocoList.ItemsSource = Locomotives.items;
            Debug.WriteLine((DateTime.Now - start).TotalMilliseconds + "ms until all locomotives were loaded");
        }

        private void LocoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LocomotiveDetail((Locomotive)e.Item));
        }
    }
}