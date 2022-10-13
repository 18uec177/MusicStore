namespace MusicStore.Data
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Album Album { get; set; }
        // public Order Order { get; set; }
        public int Price { get; set; }
        public string ShoppingCartId { get; set; }

    }
}