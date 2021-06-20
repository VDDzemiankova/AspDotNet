using Lab1.Dialogs;
using Lab1.ViewModels;
using Xamarin.Forms;

namespace Lab1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new StationeryViewModel(new DialogService());          
        }
    }
}
