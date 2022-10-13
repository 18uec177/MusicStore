using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
