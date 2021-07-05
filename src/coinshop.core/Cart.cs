using System.Collections.Generic;
using System.Linq;

namespace coinshop.core
{
    public class Cart
    {
        private string DiscountCode = "";
        private readonly Dictionary<Item, int> _items = new Dictionary<Item, int>();
        private readonly DiscountRepository _discountRepository;

        public Cart()
        {
            _discountRepository = new DiscountRepository();
        }
        public Cart(DiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public void AddItem(Item item, int quantity)
        {
            if (_items.TryGetValue(item, out var existingQuantity))
            {
                _items[item] = existingQuantity + quantity;
            }
            else
            {
                _items[item] = quantity;
            }
        }

        public Dictionary<Item, int> Items() => _items;

        public decimal SubTotal()
            => _items.Select(i => i.Key.Price * i.Value).Sum();

        public decimal Total() => SubTotal() * _discountRepository.GetDiscountOrDefault(DiscountCode);

        public void ApplyDiscount(string code)
        {
            DiscountCode = code;
        }
    }
}
