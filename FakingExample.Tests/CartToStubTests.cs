using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakingExample.Tests
{
    [TestClass]
    public class CartToStubTests
    {
        [TestMethod]
        public void AddCartItem_GivenCartAndProduct_ThenProductShouldBeAddedToCart()
        {
            int cartItemId = 42, cartId = 1, userId = 33, productId = 777;

            //Stub ICartSaver and customize the behavior via a 
            //delegate, ro return cartItemId
            var cartSaver = new Fakes.StubICartSaver();
            cartSaver.SaveCartItemInt32Int32 = (c, p) => cartItemId;

            var cart = new CartToStub(cartId, userId, cartSaver);
            cart.AddCartItem(productId);

            Assert.AreEqual(cartId, cart.CartItems.Count);
            var cartItem = cart.CartItems[0];
            Assert.AreEqual(cartItemId, cartItem.CartItemId);
            Assert.AreEqual(productId, cartItem.ProductId);
        }
    }
}
