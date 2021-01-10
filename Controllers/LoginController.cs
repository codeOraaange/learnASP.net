using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using sportstore.Models;

using Microsoft.AspNetCore.Authorization;

namespace sportstore.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public LoginController(
            Context context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
        ){
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
            // tambah unt uk tampil page
        public IActionResult Login()
        {
            return View();
        }
        //tambah untuk proses
        [HttpPost]          //untuk post file
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user!=null)
            {
                var result = await _signInManager
                                    .PasswordSignInAsync(user, password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Product", new{area = "Admin"});
                }
            }
            return View();
        } 

        public IActionResult SignUp()
        {
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> SignUp(string username, string password)
        {
            var user = new IdentityUser{UserName = username};
            var result = await _userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                var SignInResult = await _signInManager
                                    .PasswordSignInAsync(username, password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Product", new{area = "Admin"});
                }
            }
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}