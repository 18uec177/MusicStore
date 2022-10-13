using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class OrderRepository: IOrderRepository
    {

        private readonly MusicStoreContext _context;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(MusicStoreContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItem;
            foreach (var i in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = i.Price,
                    AlbumId = i.Album.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = i.Album.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
