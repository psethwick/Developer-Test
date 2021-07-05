using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace coinshop.core.tests
{
    public class CartTests
    {
        private Cart Cart { get; set; } = new Cart(new DiscountRepository(
            new Dictionary<string, decimal>
            {
                {"test", 1M}
            }));
        
        [Fact]
        public void CanAddItemToCart()
        {
            Cart.AddItem(new Item("Foo", 1), 1);
        }

        [Fact]
        public void AnEmptyCartTotalIsZero()
        {
            Cart.Total().Should().Be(0);
        }
        
        [Fact]
        public void CartTotalWithOneItemIsItemPrice()
        {
            const int itemPrice = 3;
            var item = new Item("Bar", itemPrice);
            
            Cart.AddItem(item, 1);

            Cart.Total().Should().Be(itemPrice);
        }
        
        [Fact]
        public void CanAddMultipleSameItemsToCart()
        {
            const int itemPrice = 3;
            var item = new Item("Foo", itemPrice);
            
            Cart.AddItem(item, 1);
            Cart.AddItem(item, 1);

            Cart.Total().Should().Be(itemPrice * 2);
        }
        
        [Fact]
        public void CanAddMultipleDifferentItemsToCart()
        {
            const int itemPrice = 3;
            var item1 = new Item("Foo", itemPrice);
            var item2 = new Item("Bar", itemPrice);
            
            Cart.AddItem(item1, 1);
            Cart.AddItem(item2, 1);
            Cart.AddItem(item2, 1);

            Cart.Total().Should().Be(itemPrice * 3);
        }

        [Fact]
        public void CanRemoveItemsFromCart()
        {
            var item = new Item("Foo", 3);
            
            Cart.AddItem(item, 1);
            Cart.AddItem(item, -1);

            Cart.Total().Should().Be(0);
        }
        
        [Fact]
        public void CanApplyDiscountCode()
        {
            const int itemPrice = 3;
            var item = new Item("Bar", itemPrice);

            Cart = new Cart(new DiscountRepository(new Dictionary<string, decimal>
            {
                {"fiftypercent", 0.5M}
            }));
            
            Cart.AddItem(item, 1);

            Cart.Total().Should().Be(itemPrice);
            
            Cart.ApplyDiscount("FIFTYPERCENT");

            Cart.Total().Should().Be(itemPrice / 2.0M);
            Cart.SubTotal().Should().Be(itemPrice); // sub total is unchanged
        }
    }
}
