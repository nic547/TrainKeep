﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
            IpEntry.Text = Preferences.Get("IpHostname", "localhost");
            DbEntry.Text = Preferences.Get("Database", "trainkeep");
            UserEntry.Text = Preferences.Get("Username", "tk_user");
            PwEntry.Text = Preferences.Get("Password", "tk_user01");

            ImageLoadingPicker.SelectedIndex = Preferences.Get("ImageLoadingSetting", 2);
            TileSwitch.On = Preferences.Get("TileLayout", false);
		}

        private void Value_Changed(object sender, EventArgs e)
        {

        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            TestButton.IsEnabled = false;
            string connectionString = tklib.TkSettings.BuildConnectionString(IpEntry.Text, DbEntry.Text, UserEntry.Text, PwEntry.Text);
            try
            {
                var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    FeedbackLabel.Text = "Connection succesfull";
                }
                connection.Dispose();
            }
            catch(PostgresException exc)
            {
                FeedbackLabel.Text = exc.MessageText;
            }

            catch(TimeoutException exc)
            {
                FeedbackLabel.Text = "Connection timed out";
            }
            
            TestButton.IsEnabled = true;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            tklib.TkSettings.SetConnectionString(IpEntry.Text, DbEntry.Text, UserEntry.Text, PwEntry.Text);

            Preferences.Set("IpHostname", IpEntry.Text);
            Preferences.Set("Database", DbEntry.Text);
            Preferences.Set("Username", UserEntry.Text);
            Preferences.Set("Password", PwEntry.Text);

            Preferences.Set("ImageLoadingSetting", ImageLoadingPicker.SelectedIndex);
            Preferences.Set("TileLayout", TileSwitch.On);
        }
            private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}