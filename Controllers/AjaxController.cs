using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class AjaxController : Controller
    {

        private readonly MusicStoreContext context;

        public AjaxController(MusicStoreContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AlbumList()
        {
            var data = context.Album.ToList();
            return new JsonResult(data);
        }


        [HttpPost]
        public JsonResult AddAlbum(Album album)
        {
            var alb = new Album()
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                AlbumArtUrl = album.AlbumArtUrl,
                Price = album.Price,
                GenreId = album.GenreId,
                ArtistId = album.ArtistId,
            };
            context.Album.Add(alb);
            context.SaveChanges();
            return new JsonResult("Data is saved");
        }

        public JsonResult Delete(int id)
        {
            var data = context.Album.Where(e => e.AlbumId == id).SingleOrDefault();
            context.Album.Remove(data);
            context.SaveChanges();
            return new JsonResult("Data Deleted");
        }

        public JsonResult Edit(int id)
        {
            var data = context.Album.Where(e => e.AlbumId == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Album album)
        {
            context.Album.Update(album);
            context.SaveChanges();
            return new JsonResult("Record Updated");
        }

    }
   
}
