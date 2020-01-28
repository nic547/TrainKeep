// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile.ItemPages
{
    using Tklib;
    using Tklib.Db;
    using Tklib.DbManager;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveOverviewList : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocomotiveOverviewList"/> class.
        /// </summary>
        public LocomotiveOverviewList()
        {
            BindingContext = this;
            InitializeComponent();
            LoadData();
            LocoList.ItemsSource = Database.Locomotives.Items;
        }

        private Database Database { get; set; } = DatabaseManager.GetDatabase();

        private async void LoadData()
        {
            await Database.Locomotives.Load();
        }

        private void LocoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LocomotiveDetail((Locomotive)e.Item));
        }
    }
}