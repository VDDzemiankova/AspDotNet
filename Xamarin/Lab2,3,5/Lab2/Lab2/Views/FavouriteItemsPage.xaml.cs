using Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavouriteItemsPage : ContentPage
	{
		public FavouriteItemsPage ()
		{
			InitializeComponent ();

            BindingContext = new FavouriteItemsViewModel(Navigation);
		}
	}
}