using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakingExample.Tests
{
    [TestClass]
    public class CartToShimTests
    {
        [TestMethod]
        public void AddCartItem_GivenCartAndProduct_ThenProductShouldBeAddedToCart_Shim()
        {
            //Create a context to scope and cleanup shims
            using (ShimsContext.Create())
            {
                int cartItemId = 42, cartId = 1, userId = 33, productId = 777;

                //Shim SaveCartItem rerouting it to a delegate which 
                //always returns cartItemId
                Fakes.ShimDataAccessLayer.SaveCartItemInt32Int32 = (c, p) => cartItemId;

                var cart = new CartToShim(cartId, userId);
                cart.AddCartItem(productId);

                Assert.AreEqual(cartId, cart.CartItems.Count);
                var cartItem = cart.CartItems[0];
                Assert.AreEqual(cartItemId, cartItem.CartItemId);
                Assert.AreEqual(productId, cartItem.ProductId);
            }
        }
    }
}
