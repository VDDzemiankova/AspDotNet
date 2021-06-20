using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /*private async void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case 1:
                    await Navigation.PushModalAsync(new NavigationPage(new ItemsPage()));
                    break;
                case 2:
                    await Navigation.PushModalAsync(new NavigationPage(new FavouriteItemsPage()));
                    break;
                case 3:
                    await Navigation.PushModalAsync(new NavigationPage(new MessagesPage()));
                    break;

            }
        }*/
    }
}