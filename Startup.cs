using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repository;
using System;

namespace MusicStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.ConfigureApplicationCookie(config=>
            //   {
            //       config.LoginPath = "/login";
            //   } );


            services.AddControllersWithViews();


            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/Account/Login";
            //    });

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddDbContext<MusicStoreContext>(
                options =>
        options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();


            //services.AddAuthentication("CookieAuth")
            //    .AddCookie("cookieAuth", config =>
            //    {
            //        config.Cookie.Name = "loginAuth.Cookie";
            //        config.LoginPath = "/Account/Login";
            //    });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MusicStoreContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/login";
            });

            services.AddDistributedMemoryCache();
            services.AddScoped(s => Repository.ShoppingCart.GetCart(s));
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});
        }




            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            
            //app.UseIdentity();

            app.UseRouting();

            //app.UseCookieAuthentication(options =>
            //{
            //    options.AutomaticAuthenticate = true;
            //    options.AutomaticChallenge = true;
            //    options.LoginPath = "/Home/Login";
            //});


            app.UseAuthentication();
            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ajax}/{action=Index}/{id?}");
            });
        }
    }
}
