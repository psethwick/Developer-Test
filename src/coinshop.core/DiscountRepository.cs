using System.Collections.Generic;

namespace coinshop.core
{
    public class DiscountRepository
    {
        private readonly Dictionary<string, decimal> _actualDiscounts
            = new Dictionary<string, decimal>
            {
                { "HIREME", 0.5M}
            };

        public decimal GetDiscountOrDefault(string code)
        {
            if (_actualDiscounts.TryGetValue(code, out var discount))
            {
                return discount;
            }

            return 1;
        }
    }
}