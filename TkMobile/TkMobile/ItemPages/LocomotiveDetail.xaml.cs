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
    public partial class LocomotiveDetail : ContentPage
    {
        private Item Item { get; set; }
        private ItemManager Manager { get; set; }
        private List<Item> Items { get; set; }
        public LocomotiveDetail (Item item,ItemManager manager, List<Item> items)
        {
            InitializeComponent();
            Item = item;
            BindingContext = Item;
            Manager = manager;
            Items = items;
        }

        protected async override void OnAppearing()
        {
            
            ClassPicker.ItemsSource = await Items.ToAsyncEnumerable().Select(i => i.Model.Prototype).Distinct().ToList();
            

            if (Item.Model.Prototype != null)
            {
                ClassPicker.SelectedItem = Item.Model.Prototype;
                ModelPicker.ItemsSource = Item.Model.Prototype.Models;
                ModelPicker.SelectedItem = Item.Model;
            }
        }
    }
}