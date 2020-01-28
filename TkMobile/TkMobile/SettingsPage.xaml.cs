// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Tklib.Db;
    using Tklib.DbManager;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// <see cref="ContentPage"/> containing the settings for the app.
    /// </summary>
    public partial class SettingsPage : ContentPage
    {

        private DbsConnectionSettings connectionSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage"/> class.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();

            this.ImageLoadingPicker.SelectedIndex = Preferences.Get("ImageLoadingSetting", 2);
            this.TileSwitch.On = Preferences.Get("TileLayout", false);

            var availableDatabaseSystems = DatabaseConnectionList.Get();
            connectionSettings = availableDatabaseSystems[0];

            try
            {
                string input = Preferences.Get("ConnectionSettings", null);
                var savedSettings = JsonConvert.DeserializeObject<DbsConnectionSettings>(input);

                connectionSettings = savedSettings ?? availableDatabaseSystems[0];
            }
            catch (Exception) { }

            foreach (var entry in connectionSettings.Settings)
            {
                var entryCell = new EntryCell();
                entryCell.Label = entry.Name;
                entryCell.Text = entry.Value;
                entryCell.IsEnabled = entry.DisplayToUser;

                ConnectionSettingsContainer.Insert(ConnectionSettingsContainer.Count - 1, entryCell);
            }
        }

        private void Value_Changed(object sender, EventArgs e)
        {
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            this.TestButton.IsEnabled = false;

            var database = DatabaseManager.GetDatabase();

            GatherSettings();
            var state = await database.TestConnectionSettings(connectionSettings);

            switch (state)
            {
                case Tklib.ConnectionState.IsOK:
                    this.FeedbackLabel.Text = "Connection succesfull";
                    break;

                case Tklib.ConnectionState.FailurePassword:
                    this.FeedbackLabel.Text = "Wrong Password";
                    break;

                case Tklib.ConnectionState.FailureUnspecified:
                default:
                    this.FeedbackLabel.Text = "No Connection could be established";
                    break;
            }

            this.TestButton.IsEnabled = true;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var database = DatabaseManager.GetDatabase();

            GatherSettings();
            database.ConnectionSettings = connectionSettings;

            Preferences.Set("ConnectionSettings", DatabaseManager.SerializeConnectionSettings(connectionSettings));

            Preferences.Set("ImageLoadingSetting", this.ImageLoadingPicker.SelectedIndex);
            Preferences.Set("TileLayout", this.TileSwitch.On);
        }

        private void GatherSettings()
        {
            foreach (var setting in connectionSettings.Settings)
            { // The horrible reversing twice can be replaced with SkipLast(1) once UWP supports .net standart 2.1
                setting.Value = ConnectionSettingsContainer.Reverse().Skip(1).Reverse().OfType<EntryCell>().Where(X => X.Label == setting.Name).Single().Text;
            }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}