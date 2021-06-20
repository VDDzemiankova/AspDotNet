using System;

using Lab2.Models;

namespace Lab2.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Stationery Item { get; set; }
        public ItemDetailViewModel(Stationery item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
