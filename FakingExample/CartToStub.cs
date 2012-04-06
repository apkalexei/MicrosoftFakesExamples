using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FakingExample
{
    public class CartToStub
    {
        public int CartId { get; private set; }
        public int UserId { get; private set; }
        private List<CartItem> _cartItems = new List<CartItem>();
        public ReadOnlyCollection<CartItem> CartItems { get; private set; }
        public DateTime CreateDateTime { get; private set; }
        private ICartSaver _cartSaver;

        public CartToStub(int cartId, int userId, ICartSaver cartSaver)
        {
            CartId = cartId;
            UserId = userId;
            CreateDateTime = DateTime.Now;
            _cartSaver = cartSaver;
            CartItems = new ReadOnlyCollection<CartItem>(_cartItems);
        }

        public void AddCartItem(int productId)
        {
            var cartItemId = _cartSaver.SaveCartItem(CartId, productId);
            _cartItems.Add(new CartItem(cartItemId, productId));
        }
    }
}
