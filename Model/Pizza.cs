using System.Collections.Generic;
using System.Globalization;

namespace BlazingPizza
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }

        public int OrderId { get; set; }

        public PizzaSpecial Special { get; set; } = new PizzaSpecial();

        public int SpecialId { get; set; }

        public int Size { get; set; } = DefaultSize;

        public List<PizzaTopping> Toppings { get; set; } = new List<PizzaTopping>();

        /// <summary>
        /// Calculates the base price based on pizza size.
        /// </summary>
        public decimal GetBasePrice()
        {
            return ((decimal)Size / DefaultSize) * Special.BasePrice;
        }

        /// <summary>
        /// Calculates total price including toppings (if added later).
        /// </summary>
        public decimal GetTotalPrice()
        {
            return GetBasePrice(); // Add toppings cost here if needed
        }

        /// <summary>
        /// Returns the total price formatted in Jamaican Dollars (J$) with no decimals.
        /// </summary>
        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("C0", CultureInfo.CurrentCulture);
        }
    }
}
