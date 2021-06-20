using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;


[assembly: Xamarin.Forms.Dependency(typeof(Lab2.Services.MockDataStore))]
namespace Lab2.Services
{
    public class MockDataStore : IDataStore<Stationery>
    {
        List<Stationery> items;

        public MockDataStore()
        {
            items = new List<Stationery>();
            var mockItems = new List<Stationery>
            {
                new Stationery
                    {
                        Id = 1,
                        Name = "Черноморские",
                        Producer = "Спартак",
                        Price = 1.30m,
                        Image = "Sea.jpg",
                        SellDate = DateTime.Now

                    },
                    new Stationery
                    {
                        Id = 2,
                        Name = "Сливочные",
                        Producer = "Комунарка",
                        Price = 1.30m,
                        Image = "Sl.jpg",
                        SellDate = DateTime.Now

                    },
                    new Stationery
                    {
                        Id = 3,
                        Name = "Лимонные",
                        Producer = "Рошен",
                        Price = 1.43m,
                        Image = "L.jpg",
                        SellDate = DateTime.Now

                    }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Stationery item)
        {
            item.Id = items.Max(it => it.Id) + 1;
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Stationery item)
        {
            var oldItem = items.Where((Stationery arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Stationery arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Stationery> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Stationery>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}