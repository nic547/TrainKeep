// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile.ItemPages
{
    using System;
    using System.IO;
    using System.Linq;
    using Tklib;
    using Tklib.Db;
    using Tklib.DbManager;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class LocomotiveDetail : ContentPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore SA1601 // Partial elements should be documented
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocomotiveDetail"/> class.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> for which the detail page should be shown.</param>
        public LocomotiveDetail(Item item)
        {
            Item = item;
            BindingContext = Item;
            InitializeComponent();
            ImageThing.Source = ImageSource.FromResource("TkMobile.DefaultImage.jpg");
        }

        private Item Item { get; }
        private Model model { get; set; }
        private Prototype prototype { get; set; }

        private Database Database { get; } = DatabaseManager.GetDatabase();

        /// <inheritdoc/>
        protected async override void OnAppearing()
        {
            ProtoPicker.ItemsSource = Database.Locomotives.Prototypes.Values.ToList();
            ProtoPicker.SelectedItem = Item?.Model?.Prototype;

            // Not done via bindings because I'm not smart enough to stop it from displaying zero that way.
            DCCCell.Text = Item.Dcc != 0 ? Item.Dcc.ToString() : string.Empty;

            UpdateModelSelector();

            await Database.Locomotives.LoadImage(Item);

            if (Item.Image != null)
            {
                ImageThing.Source = ImageSource.FromStream(() => new MemoryStream(Item.Image.ToArray()));
            }
        }

        private void UpdateModelSelector()
        {
            ModelPicker.ItemsSource = Database.Locomotives.Models.Values.Where(x => x.Prototype == ProtoPicker.SelectedItem).ToList();
            ModelPicker.SelectedItem = Item?.Model;
        }

        private void ProtoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            UpdateModelSelector();
        }

        private async void ToolbarNewModel_Clicked(object sender, EventArgs e)
        {
            void Action(string result)
            {
                Database.Locomotives.Insert(new Model() { Name = result, Prototype = (Prototype)ProtoPicker.SelectedItem });
            }

            await Navigation.PushModalAsync(new PromptPage("Enter the name of the model", Action));
        }

        private async void ToolbarNewProto_Clicked(object sender, EventArgs e)
        {
            void Action(string result)
            {
                Database.Locomotives.Insert(new Prototype() { Name = result });
            }

            await Navigation.PushModalAsync(new PromptPage("Enter the name of the prototype", Action));
        }
    }
}