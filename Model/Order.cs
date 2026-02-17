using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BlazingPizza
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public Address DeliveryAddress { get; set; } = new Address();
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

public string GetFormattedTotalPrice()
{
    return GetTotalPrice().ToString("C0", new CultureInfo("en-JM"));
}
    }
}
