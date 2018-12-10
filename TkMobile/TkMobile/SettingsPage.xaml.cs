using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TkLib.Dal;

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

        private void TestButton_Clicked(object sender, EventArgs e)
        {
            TestButton.IsEnabled = false;
            try { 
            using (var context = new TrainKeepContext())
                {
                    context.Database.EnsureCreated();
                }
            }

            catch (Exception exc)
            {

            }
            TestButton.IsEnabled = true;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            TkLib.BusinessLayer.ManagerBase.SetConnectionString(IpEntry.Text, DbEntry.Text, UserEntry.Text, PwEntry.Text);

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