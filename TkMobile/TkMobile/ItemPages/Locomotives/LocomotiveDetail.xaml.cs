﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using tklib;
using System.IO;

namespace TkMobile.ItemPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveDetail : ContentPage
    {
        protected Locomotive Item { get; }
        protected Locomotives Locomotives { get; }

        public LocomotiveDetail (Locomotives locomotives,Locomotive item)
        {   Item = item;
            BindingContext = Item;
            Locomotives = locomotives;
            InitializeComponent();
            ImageThing.Source = ImageSource.FromResource("TkMobile.DefaultImage.jpg");
        }

        async protected override void OnAppearing()
        {
            ProtoPicker.ItemsSource = Locomotives.Prototypes.Values.ToList();
            ProtoPicker.SelectedItem = Item.Model.Prototype;

            ModelPicker.ItemsSource = Locomotives.Models.Values.Where(x => x.Prototype == ProtoPicker.SelectedItem).ToList();
            ModelPicker.SelectedItem = Item.Model;

            await Item.LoadImage();
            ImageThing.Source = ImageSource.FromStream(() => new MemoryStream(Item.Image.ToArray()));
        }
    }
}