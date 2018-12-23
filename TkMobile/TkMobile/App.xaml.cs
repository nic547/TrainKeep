using tklib;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TkMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            TkDatabase.SetConnectionString(
                Preferences.Get("IpHostname", "localhost"),
                Preferences.Get("Database", "trainkeep"),
                Preferences.Get("Username", "tk_user"),
                Preferences.Get("Password", "tk_user01")
                );

            TkDatabase.WarmupConnections();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Npgsql.NpgsqlConnection.ClearAllPools();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
