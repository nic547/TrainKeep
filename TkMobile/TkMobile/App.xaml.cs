// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

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
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
            Database database = DatabaseManager.GetDatabase();
            var settings = DatabaseManager.TryDeserializeConnectionSettings(Preferences.Get("ConnectionString", string.Empty));
            database.ConnectionSettings = settings ?? DatabaseConnectionList.Get()[0];
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
