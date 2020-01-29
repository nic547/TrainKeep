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

#pragma warning disable SA1601 // Partial elements should be documented
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class SettingsPage : ContentPage
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore SA1601 // Partial elements should be documented
    {
        private DbsConnectionSettings connectionSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage"/> class.
        /// </summary>
        public SettingsPage()
        {
            InitializeComponent();

            ImageLoadingPicker.SelectedIndex = Preferences.Get("ImageLoadingSetting", 2);
            TileSwitch.On = Preferences.Get("TileLayout", false);

            var availableDatabaseSystems = DatabaseConnectionList.Get();
            connectionSettings = availableDatabaseSystems[0];

            try
            {
                string input = Preferences.Get("ConnectionSettings", null);
                var savedSettings = JsonConvert.DeserializeObject<DbsConnectionSettings>(input);

                connectionSettings = savedSettings ?? availableDatabaseSystems[0];
            }
            catch (Exception)
            {
            }

            foreach (var entry in connectionSettings.Settings)
            {
                var entryCell = new EntryCell
                {
                    Label = entry.Name,
                    Text = entry.Value,
                    IsEnabled = entry.DisplayToUser,
                };

                ConnectionSettingsContainer.Insert(ConnectionSettingsContainer.Count - 1, entryCell);
            }
        }

        private void Value_Changed(object sender, EventArgs e)
        {
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            TestButton.IsEnabled = false;

            var database = DatabaseManager.GetDatabase();

            GatherSettings();
            var state = await database.TestConnectionSettings(connectionSettings);

            FeedbackLabel.Text = state switch
            {
                Tklib.ConnectionState.IsOK => "Connection succesfull",
                Tklib.ConnectionState.FailurePassword => "Wrong Password",
                _ => "No Connection could be established",
            };
            TestButton.IsEnabled = true;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var database = DatabaseManager.GetDatabase();

            GatherSettings();
            database.ConnectionSettings = connectionSettings;

            Preferences.Set("ConnectionSettings", DatabaseManager.SerializeConnectionSettings(connectionSettings));

            Preferences.Set("ImageLoadingSetting", ImageLoadingPicker.SelectedIndex);
            Preferences.Set("TileLayout", TileSwitch.On);
        }

        private void GatherSettings()
        {
            foreach (var setting in connectionSettings.Settings)
            { // The horrible reversing twice can be replaced with SkipLast(1) once UWP supports .net standart 2.1
                setting.Value = ConnectionSettingsContainer.Reverse().Skip(1).Reverse().OfType<EntryCell>().Where(x => x.Label == setting.Name).Single().Text;
            }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}