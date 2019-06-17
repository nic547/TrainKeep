namespace TkMobile
{
    using System;
    using Tklib.DbManager;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            this.IpEntry.Text = Preferences.Get("IpHostname", "localhost");
            this.DbEntry.Text = Preferences.Get("Database", "trainkeep");
            this.UserEntry.Text = Preferences.Get("Username", "tk_user");
            this.PwEntry.Text = Preferences.Get("Password", "tk_user01");

            this.ImageLoadingPicker.SelectedIndex = Preferences.Get("ImageLoadingSetting", 2);
            this.TileSwitch.On = Preferences.Get("TileLayout", false);
        }

        private void Value_Changed(object sender, EventArgs e)
        {

        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            this.TestButton.IsEnabled = false;

            this.TestButton.IsEnabled = true;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var database = DatabaseManager.GetDatabase();

            database.SetConnectionString(this.IpEntry.Text, this.DbEntry.Text, this.UserEntry.Text, this.PwEntry.Text);

            Preferences.Set("IpHostname", this.IpEntry.Text);
            Preferences.Set("Database", this.DbEntry.Text);
            Preferences.Set("Username", this.UserEntry.Text);
            Preferences.Set("Password", this.PwEntry.Text);

            Preferences.Set("ImageLoadingSetting", this.ImageLoadingPicker.SelectedIndex);
            Preferences.Set("TileLayout", this.TileSwitch.On);
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}