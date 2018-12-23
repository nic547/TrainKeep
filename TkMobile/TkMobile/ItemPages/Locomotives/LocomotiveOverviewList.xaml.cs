using tklib;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveOverviewList : ContentPage
    {
        public Locomotives Locomotives { get; set; }
        public LocomotiveOverviewList()
        {
            Locomotives = new Locomotives();
            BindingContext = this;
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            await Locomotives.Load();
        }

        private void LocoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new LocomotiveDetail(Locomotives,(Locomotive)e.Item));
        }
    }
}