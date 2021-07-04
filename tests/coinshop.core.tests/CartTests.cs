using Xunit;

namespace coinshop.core.tests
{
    public class CartTests
    {
        public Cart Cart { get; set; } = new Cart();
        
        [Fact]
        public void CanAddItemToCart()
        {
            Cart.AddItem(new Item());
        }
        
        [Fact]
        public void CanAddMultipleItemsToCart()
        {
        }

        [Fact]
        public void CanRemoveItemsFromCart()
        {
            
        }
        
        [Fact]
        public void CanApplyDiscountCode()
        {
        }
    }
}
