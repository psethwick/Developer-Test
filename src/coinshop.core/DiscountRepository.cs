using System.Collections.Generic;

namespace coinshop.core
{
    public class DiscountRepository
    {
        private readonly Dictionary<string, decimal> _discounts;

        public DiscountRepository(Dictionary<string, decimal> discounts)
        {
            _discounts = discounts;
        }

        public decimal GetDiscountOrDefault(string code)
        {
            if (_discounts.TryGetValue(code.ToLower(), out var discount))
            {
                return discount;
            }

            return 1;
        }
    }
}