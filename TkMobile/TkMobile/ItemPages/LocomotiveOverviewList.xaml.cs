using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<Item> Items { get; set; }
		public LocomotiveOverviewList ()
		{
            Manager = new ItemManager();
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            var start = DateTime.Now;
            
            // This should be done with Async, but Npgsql seems to have an issue with that
            // Reset() called on connector with state Connecting
            // this seems to be the related issue https://github.com/npgsql/npgsql/issues/1127

            Items = await Task.Run(() => Manager.List);
            LocoList.ItemsSource = Items;

            Debug.WriteLine((DateTime.Now - start).TotalMilliseconds + " ms until OnAppearing finished");
        }
        private void LocoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LocomotiveDetail((Item)e.Item,Manager, Items));
        }
    }
}