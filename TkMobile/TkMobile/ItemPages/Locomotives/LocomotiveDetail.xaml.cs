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

    // ggzggzgzgz
    public partial class LocomotiveDetail : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocomotiveDetail"/> class.
        /// </summary>
        /// <param name="item">The <see cref="Locomotive"/> for which the detail page should be shown.</param>
        public LocomotiveDetail(Locomotive item)
        {
            Item = item;
            BindingContext = Item;
            InitializeComponent();
            ImageThing.Source = ImageSource.FromResource("TkMobile.DefaultImage.jpg");
        }

        private Locomotive Item { get; }

        private Database Database { get; } = DatabaseManager.GetDatabase();

        /// <inheritdoc/>
        protected async override void OnAppearing()
        {
            ProtoPicker.ItemsSource = Database.Locomotives.Prototypes.Values.ToList();
            ProtoPicker.SelectedItem = Item.Model.Prototype;

            ModelPicker.ItemsSource = Database.Locomotives.Models.Values.Where(x => x.Prototype == ProtoPicker.SelectedItem).ToList();
            ModelPicker.SelectedItem = Item.Model;

            await Database.Locomotives.LoadImage(Item);

            if (Item.Image != null)
            {
                ImageThing.Source = ImageSource.FromStream(() => new MemoryStream(Item.Image.ToArray()));
            }
        }
    }
}