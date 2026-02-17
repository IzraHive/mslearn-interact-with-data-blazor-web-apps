using System.Globalization;

namespace BlazingPizza
{
    /// <summary>
    /// Represents a pre-configured pizza a user can order
    /// </summary>
    public class PizzaSpecial
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Returns the base price formatted in Jamaican Dollars (J$) with no decimals
        /// </summary>
        public string GetFormattedBasePrice()
        {
            return BasePrice.ToString("C0", CultureInfo.CurrentCulture);
        }
    }
}
