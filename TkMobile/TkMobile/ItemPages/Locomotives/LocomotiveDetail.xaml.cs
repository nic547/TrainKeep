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
        private Item itemCopy;

        private Model modelCopy;

        private Prototype prototypeCopy;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocomotiveDetail"/> class.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> for which the detail page should be shown.</param>
        public LocomotiveDetail(Item item)
        {
            itemCopy = item.Clone();
            modelCopy = itemCopy.Model;
            prototypeCopy = modelCopy?.Prototype;

            BindingContext = itemCopy;

            InitializeComponent();

            DefaultImage.Source = ImageSource.FromResource("TkMobile.DefaultImage.webp", this.GetType().Assembly);

            ModelSection.BindingContext = modelCopy;
            ProtoSection.BindingContext = prototypeCopy;

            OnInitialisation();
        }

        private Database Database { get; } = DatabaseManager.GetDatabase();

        /// <summary>
        /// Stuff that needs to happen after the Page has been initalized and can/should happen async.
        /// </summary>
        protected async void OnInitialisation()
        {
            ProtoPicker.ItemsSource = Database.Locomotives.Prototypes.Values.ToList();
            ProtoPicker.SelectedItem = itemCopy?.Model?.Prototype;

            UpdateModelSelector();
            ModelPicker.SelectedItem = itemCopy?.Model;

            await Database.Locomotives.LoadImage(itemCopy);

            if (itemCopy.Image != null)
            {
                ImageThing.Source = ImageSource.FromStream(() => new MemoryStream(itemCopy.Image.ToArray()));
                _ = ImageThing.FadeTo(1);
                _ = DefaultImage.FadeTo(0);
            }
        }

        private void UpdateModelSelector()
        {
            ModelPicker.ItemsSource = Database.Locomotives.Models.Values.Where(x => x.Prototype.Id == ((Prototype)ProtoPicker.SelectedItem)?.Id).ToList();
        }

        private void ProtoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModelSelector();
            prototypeCopy = ((Prototype)ProtoPicker.SelectedItem)?.Clone();
            ProtoSection.BindingContext = prototypeCopy;
        }

        private async void ToolbarNewModel_Clicked(object sender, EventArgs e)
        {
            void Action(string result)
            {
                Database.Locomotives.Save(new Model() { Name = result, Prototype = (Prototype)ProtoPicker.SelectedItem });
            }

            await Navigation.PushModalAsync(new PromptPage("Enter the name of the model", Action));
        }

        private async void ToolbarNewProto_Clicked(object sender, EventArgs e)
        {
            void Action(string result)
            {
                Database.Locomotives.Save(new Prototype() { Name = result });
            }

            await Navigation.PushModalAsync(new PromptPage("Enter the name of the prototype", Action));
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            itemCopy.Model = modelCopy;
            itemCopy.Model.Prototype = prototypeCopy;

            Database.Locomotives.Save(itemCopy);

            Navigation.PopAsync();
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void ModelPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelCopy = (Model)ModelPicker.SelectedItem;
            ModelSection.BindingContext = modelCopy;
        }
    }
}