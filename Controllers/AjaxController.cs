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


    }
}
