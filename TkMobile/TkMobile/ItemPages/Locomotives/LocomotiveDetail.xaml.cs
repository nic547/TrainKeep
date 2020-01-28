// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile.ItemPages
{
    using System.IO;
    using System.Linq;
    using Tklib;
    using Tklib.Db;
    using Tklib.DbManager;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveDetail : ContentPage
    {
        public LocomotiveDetail(Locomotive item)
        {
            this.Item = item;
            this.BindingContext = this.Item;
            this.InitializeComponent();
            this.ImageThing.Source = ImageSource.FromResource("TkMobile.DefaultImage.jpg");
        }

        protected Locomotive Item { get; }

        protected Database Database { get; } = DatabaseManager.GetDatabase();

        /// <inheritdoc/>
        protected async override void OnAppearing()
        {
            this.ProtoPicker.ItemsSource = this.Database.Locomotives.Prototypes.Values.ToList();
            this.ProtoPicker.SelectedItem = this.Item.Model.Prototype;

            this.ModelPicker.ItemsSource = this.Database.Locomotives.Models.Values.Where(x => x.Prototype == this.ProtoPicker.SelectedItem).ToList();
            this.ModelPicker.SelectedItem = this.Item.Model;

            await this.Database.Locomotives.LoadImage(this.Item);

            if (this.Item.Image != null)
            {
                this.ImageThing.Source = ImageSource.FromStream(() => new MemoryStream(this.Item.Image.ToArray()));
            }
        }
    }
}