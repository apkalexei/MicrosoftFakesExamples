namespace FakingExample
{
    public class CartItem
    {
        public int CartItemId { get; private set; }
        public int ProductId { get; private set; }

        public CartItem(int cartItemId, int productId)
        {
            CartItemId = cartItemId;
            ProductId = productId;
        }
    }
}
