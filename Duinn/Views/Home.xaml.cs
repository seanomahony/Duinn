using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Duinn.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = ViewModels.HomePageViewModel.Instance;
        }

        private async void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            await EventPersistence.LoadEventsAsync();
            ViewModels.HomePageViewModel.Instance.LoadEvents();
        }
    }
}