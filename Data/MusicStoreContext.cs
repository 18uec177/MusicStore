using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Models;
using Microsoft.AspNetCore.Identity;
using MusicStore.Data;

namespace MusicStore.Data
{
    public class MusicStoreContext: IdentityDbContext<ApplicationUser>
    {
        
        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
                    : base(options)
        {

        }

        public DbSet<Album> Album { get; set; }

        public DbSet<Genre> Genre { get; set; }

        //public DbSet<User> User { get; set; }

        public DbSet<Artist> Artist { get; set; }
        
        //public DbSet<MusicStore.Models.SignUpUserModel> SignUpUserModel { get; set; }

        //public DbSet<MusicStore.Models.SignInModel> SignInModel { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MusicStore.Models.SignInModel> SignInModel { get; set; }
        

    }
}
