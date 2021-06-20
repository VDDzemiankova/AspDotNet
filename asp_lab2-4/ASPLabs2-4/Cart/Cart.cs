using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ASPLabs2_4.Cart
{
    public class Cart
    {
        
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Car car, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Car.Id == car.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Car = car,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Car car)
        {
            lineCollection.RemoveAll(l => l.Car.Id == car.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Car.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public class CartLine
        {
            public Car Car { get; set; }
            public int Quantity { get; set; }
        }
    }
}