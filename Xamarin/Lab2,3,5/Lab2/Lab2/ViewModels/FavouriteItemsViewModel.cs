using Lab2.Models;
using Lab2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2.ViewModels
{
    class FavouriteItemsViewModel : ItemsViewModel
    {
        public ObservableCollection<Grouping<string, Stationery>> ItemGroups { get; set; }

        public FavouriteItemsViewModel(INavigation navigation) : base(navigation)
        {
            Title = "Избранные продукты";
            var items = DataStore.GetItemsAsync().Result;
            CreateGroups(items);
        }

        protected override async Task Reload()
        {
            await base.Reload();
            CreateGroups(Items);

        }

        private void CreateGroups(IEnumerable<Stationery> items)
        {
            var groups = items.GroupBy(s => s.Producer).Select(g => new Grouping<string, Stationery>(g.Key, g));
            ItemGroups = new ObservableCollection<Grouping<string, Stationery>>(groups);
            OnPropertyChanged("ItemGroups");
        }
    }
}
