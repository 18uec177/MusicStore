using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class AccountRepository: IAccountRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        
        }
        
        

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email

            };
           var result = await _userManager.CreateAsync(user, userModel.Password);
           return result;
        }
          

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
           var result= await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }


        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }



        }
    }

