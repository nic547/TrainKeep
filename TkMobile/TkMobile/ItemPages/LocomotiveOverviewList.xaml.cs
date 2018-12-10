using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TkLib.BusinessLayer;
using TkLib.Dal.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocomotiveOverviewList : ContentPage
	{
        public ItemManager Manager { get; }
		public LocomotiveOverviewList ()
		{
            Manager = new ItemManager();
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            LocoList.ItemsSource = Manager.List;
        }
        private void LocoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LocomotiveDetail((Item)e.Item));
        }
    }
}