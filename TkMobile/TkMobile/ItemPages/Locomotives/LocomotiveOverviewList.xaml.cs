using Tklib;
using Tklib.Db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveOverviewList : ContentPage
    {
        private Database Database { get; set; } = DatabaseManager.GetDatabase();
        public LocomotiveOverviewList()
        {
            BindingContext = this;
            InitializeComponent();
            LoadData();
            LocoList.ItemsSource = Database.Locomotives.Items;

            var test = DatabaseManager.GetDatabase();
        }

        private async void LoadData()
        {
            await Database.Locomotives.Load();
            { };
        }

        private void LocoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LocomotiveDetail((Locomotive)e.Item));
        }
    }
}