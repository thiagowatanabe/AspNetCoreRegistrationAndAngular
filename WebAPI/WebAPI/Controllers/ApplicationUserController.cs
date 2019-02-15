using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<object> PostApplicationUser([FromBody]ApplicationUserModel userModel){
            
            var applicationUser = new ApplicationUser{
                UserName = userModel.UserName,
                Email = userModel.Email,
                FullName = userModel.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser,userModel.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}