using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IAlbumRepository _albumRepository = null;
        private readonly IGenreRepository _genreRepository = null;

        public StoreController(IAlbumRepository albumRepository, IGenreRepository genreRepository)
        {
            _albumRepository = albumRepository;
            _genreRepository = genreRepository;
        }

        // GET: StoreController
        public async Task<ViewResult> Index()
        {
            var data = await _genreRepository.GetAllGenre();
            return View(data);
        }

        // GET: StoreController/Create
        public async Task<ViewResult> Browse(int id)
        {
            var data = await _albumRepository.GetAlbumsById(id);
            return View(data);
        }

        // GET: StoreController/Details/5
        public async Task<ViewResult> Details(int id)
        {
            var data = await _albumRepository.GetAlbumsDetails(id);
            return View(data);
        }

    }
}
