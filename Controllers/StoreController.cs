using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly MusicStoreContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StoreController(MusicStoreContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: StoreManager
        // [Authorize]
        // [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //var musicStoreContext = _context.Album.Include(a => a.Artist).Include(a => a.Genre);
            //return View(await musicStoreContext.ToListAsync());
            return View();
        }


        //public ActionResult Create()
        //{
        //    var model = new AlbumModel();
        //    model.GenreSelectList = GenreSelectList();
        //    return View("_CreatePartial", model);
        //}
        // GET: StoreManager/Details/5
        public JsonResult GetAll()
        {
            List<Album> _list = new AlbumRepository(_context).GetAlbums();
            return Json(_list);
        }

        public JsonResult Getbyid(int id)
        {
            Album _list = new AlbumRepository(_context).Getbyid(id);
            return Json(_list);
        }

        public JsonResult remove(int id)
        {
            Album _list = new AlbumRepository(_context).Getbyid(Convert.ToInt32(id));
            return Json(_list);
        }

        public JsonResult Save(Album album)
        {
            string _list = new AlbumRepository(_context).Save(album);
            return Json(_list);
        }
        public async Task<IActionResult> Details(int? id)
        {
            //var musicStoreContext = _context.Album.Include(a => a.Artist).Include(a => a.Genre);
            ViewBag.musicStoreContext = _context.Album.Include(a => a.Artist).Include(a => a.Genre);
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            //return View(album);
            //return View("Index", await musicStoreContext.ToListAsync());
            return View("Index");
        }

        // GET: StoreManager/Create
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId");
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId");
            return View("Index");
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var album = await _context.Album.FindAsync(id);
             ViewBag.album = await _context.Album.FindAsync(id); 
            if (ViewBag.album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", ViewBag.album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", ViewBag.album.GenreId);
            //return View(album);
            //return PartialView("_EditAlbumPartialView", album);
            return View("Index", ViewBag.album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", album.GenreId);
            //return PartialView("_EditAlbumPartialView",album);
            return View("Index");
        }

        // GET: StoreManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Album.FindAsync(id);
            _context.Album.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumId == id);
        }

    }
}
