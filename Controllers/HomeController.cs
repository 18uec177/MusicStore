using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlbumRepository _albumRepository = null;

        //MusicStoreContext db = new MusicStoreContext();

        public object Configuration { get; private set; }

        public HomeController(ILogger<HomeController> logger, IAlbumRepository albumRepository)
        {
            _logger = logger;
            _albumRepository = albumRepository;
        }



      //  public async Task<ViewResult> Index()
        public ViewResult Index()
        {
            //var data = await  _albumRepository.GetAlbums();
            var data =  _albumRepository.GetAlbums();
            return View(data);
        }


        //HttpGet("login")]
        //public IActionResult Login()
        //{
          //  return View();
        //}

        //[HttpPost("login")]
        //public IActionResult Login(User u, string ReturnUrl)
        //{
            //if (ModelState.IsValid)
            //{
            //    FormsAuthentication.SetAuthCookie(u.Name, false);
            //    Session["username"] = u.Name.ToString();
            //    if (ReturnUrl != null)
            //    {
            //        return Redirect(ReturnUrl);

            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //////else
            //{
              // return View();
            //}

            //var username = Configuration["name"];
            //var password = Configuration["password"];
            //if (authUser.Username == username && authUser.Password == password)
            //{
            //    var identity = new ClaimsIdentity(claims,
            //        CookieAuthenticationDefaults.AuthenticationScheme);

            //    HttpContext.Authentication.SignInAsync(
            //      CookieAuthenticationDefaults.AuthenticationScheme,
            //      new ClaimsPrincipal(identity));

            //    return Redirect("~/Home/Index");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Login failed. Please check Username and/or password");
            //}

        

        public IActionResult GetDetailsByGenre(string genre)
            {
                var genreModel = new Genre { Name = genre };
                return View(genreModel.GenreId);


            }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
