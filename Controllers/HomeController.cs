using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sportstore.Models;


//tambah 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace sportstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        
        //tambah ini
        IHostingEnvironment _env;

        //AppDbContext apa Context untuk _context ?
        private readonly DbContext _context;
        // private readonly AppDbContext _context;

        // private readonly UserManager<IdentityUser> _userManager;
        // private readonly SignInManager<IdentityUser> _signInManager;
        

        public HomeController(
            ILogger<HomeController> logger,
            IHostingEnvironment env,

            // //tambah
            Context context
            // AppDbContext context, ???
        )
        {
            _logger = logger;
            //tambah, juga di atas + env tanpa spasi
             _env = env;
            
             _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
