using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class ShoppingCart
    {
        private readonly MusicStoreContext _context;
        public ShoppingCart(MusicStoreContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItem { get; set; }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var ctext = services.GetService<MusicStoreContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(ctext) { ShoppingCartId = cartId };
        }

        public void AddToCart(Album album, int price)
        {
            var shoppingcartitem = _context.ShoppingCartItem.SingleOrDefault(s => s.Album.AlbumId == album.AlbumId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingcartitem == null)
            {
                shoppingcartitem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Album = album,
                    Price = 1,
                };

                _context.ShoppingCartItem.Add(shoppingcartitem);
            }
            else
            {
                shoppingcartitem.Price++;

            }
            _context.SaveChanges();

        }

        public int RemoveFromCart(Album album)
        {
            var shoppingcartitem = _context.ShoppingCartItem.SingleOrDefault(s => s.Album.AlbumId == album.AlbumId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;
            if (shoppingcartitem != null)
            {
                if (shoppingcartitem.Price > 1)
                {
                    shoppingcartitem.Price--;
                    localAmount = shoppingcartitem.Price;
                }
                else
                {
                    _context.ShoppingCartItem.Remove(shoppingcartitem);
                }
            }
            _context.SaveChanges();
            return localAmount;

        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItem ?? (ShoppingCartItem = _context.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Album).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context.ShoppingCartItem.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _context.ShoppingCartItem.RemoveRange(cartItems);
            _context.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Album.Price * c.Price).Sum();
            return total;
        }



    }
}
