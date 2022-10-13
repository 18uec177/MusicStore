using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Repository;
using MusicStore.ViewModels;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly Repository.ShoppingCart _shoppingCart;
        private readonly MusicStoreContext _context = null;

        public ShoppingCartController(IAlbumRepository albumRepository, Repository.ShoppingCart shoppingCart, MusicStoreContext context)
        {
            _albumRepository = albumRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItem = items;

            var scvm = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(scvm);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {

            var selectedAlbum = _albumRepository.Albums.FirstOrDefault(p => p.AlbumId == Id);
            if (selectedAlbum != null)
            {
                _shoppingCart.AddToCart(selectedAlbum, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {

            var selectedAlbum = _albumRepository.Albums.FirstOrDefault(p => p.AlbumId == Id);
            if (selectedAlbum != null)
            {
                _shoppingCart.RemoveFromCart(selectedAlbum);
            }
            return RedirectToAction("Index");
        }
    }


}

