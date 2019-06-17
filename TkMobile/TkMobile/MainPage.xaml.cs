﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Tklib.Db;

namespace TkMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SettingsPage());
        }

        private void LocomotiveButton_Click(object sender,EventArgs e)
        {
            if (Preferences.Get("TileLayout", false)) {
                Navigation.PushAsync(new ItemPages.LocomotiveOverviewTile());
            }
            else
            {
                Navigation.PushAsync(new ItemPages.LocomotiveOverviewList());
            }
        }
    }
}
