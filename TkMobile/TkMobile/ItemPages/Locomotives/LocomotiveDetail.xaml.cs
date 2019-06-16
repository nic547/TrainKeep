using System.IO;
using System.Linq;
using tklib;
using tklib.db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TkMobile.ItemPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocomotiveDetail : ContentPage
    {
        protected Locomotive Item { get; }
        protected Database Database { get; set; } = DatabaseManager.GetDatabase();

        public LocomotiveDetail(Locomotive item)
        {
            Item = item;
            BindingContext = Item;
            InitializeComponent();
            ImageThing.Source = ImageSource.FromResource("TkMobile.DefaultImage.jpg");
        }

        async protected override void OnAppearing()
        {
            ProtoPicker.ItemsSource = Database.Locomotives.Prototypes.Values.ToList();
            ProtoPicker.SelectedItem = Item.Model.Prototype;

            ModelPicker.ItemsSource = Database.Locomotives.Models.Values.Where(x => x.Prototype == ProtoPicker.SelectedItem).ToList();
            ModelPicker.SelectedItem = Item.Model;

            await Item.LoadImage();

            if (Item.Image != null)
            {
                ImageThing.Source = ImageSource.FromStream(() => new MemoryStream(Item.Image.ToArray()));
            }
        }
    }
}