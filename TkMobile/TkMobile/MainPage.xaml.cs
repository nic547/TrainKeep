// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile
{
    using System;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    /// Main starting page of the application.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SettingsPage());
        }

        private void LocomotiveButton_Click(object sender, EventArgs e)
        {
            if (Preferences.Get("TileLayout", false))
            {
                Navigation.PushAsync(new ItemPages.LocomotiveOverviewTile());
            }
            else
            {
                Navigation.PushAsync(new ItemPages.LocomotiveOverviewList());
            }
        }
    }
}
