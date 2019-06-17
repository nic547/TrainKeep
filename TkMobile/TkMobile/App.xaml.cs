using Tklib;
using Tklib.Db;
using Tklib.DbManager;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TkMobile
{
    /// <inheritdoc/>
    public partial class App : Application
    {
        /// <inheritdoc/>
        public App()
        {
            this.InitializeComponent();
            this.MainPage = new NavigationPage(new MainPage());
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
           Database database = DatabaseManager.GetDatabase();

           database.SetConnectionString(
                Preferences.Get("IpHostname", "localhost"),
                Preferences.Get("Database", "trainkeep"),
                Preferences.Get("Username", "tk_user"),
                Preferences.Get("Password", "tk_user01")
                );

           database.WarmupConnectionsAsync();
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Npgsql.NpgsqlConnection.ClearAllPools();
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
