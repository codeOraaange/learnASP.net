using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sportstore.Models;
using sportstore.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

//tambah
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace sportstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class ProductController : Controller
    {
    
        readonly Context _context;
        private readonly IHostingEnvironment _env;
        //iHosting tadinya merah?


        public ProductController (Context context, IHostingEnvironment env)
        {
            _context = context; 
            _env = env;
        }
        public IActionResult Index (int? pageNumber)
        {
            int pageSize = 3;

            IQueryable<Product>data=
                _context.Product;

            var result = PaginationHelper<Product>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );
            // List<Product> products = 
            //     _context.Product.ToList();
            return View(result);
        }


        //tambah lagi ?

        public IActionResult Create()
        {
            ViewBag.CategoryList=
                _context.Category
                .Select(x=>new SelectListItem{
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name","Price","Description","CatId")]Product product, IFormFile img
        )
        {
            if(ModelState.IsValid){
                try
                {
                    // product.Category=
                    // _context.Category
                    // .FirstOrDefault(x => x.Id == product.CatId);

                    // _context.Add(product);
                    // _context.SaveChanges();

                    if(img == null)
                    {
                        return NotFound();
                    }
                    string fileName = img.FileName;
                    string filePath = Path.Combine(_env.WebRootPath, "uploads/img");
                    string fullPath = Path.Combine(filePath, fileName);
                    if(!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create) )
                    {
                        await img.CopyToAsync(stream);
                    }
                    string gPath = @"/uploads/img";
                    string dbPath = Path.Combine(gPath, fileName);
                    product.img = dbPath;


                    product.Category = _context.Category.FirstOrDefault(x=>x.Id==product.CatId);
                   
                   //sesuai nama var di model(img)
                    
                    _context.Add(product);
                    _context.SaveChanges(); 
                
                }
                catch(Exception e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            Product product =
            _context.Product.Where (x=> x.Id==id)
            .FirstOrDefault();
            return View (product);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(
            [Bind("Id", "Name","Price","Description")]Product product, IFormFile img
        )
        {
            if(ModelState.IsValid){
               try
                {
                   if(img == null)
                    {
                        return NotFound();
                    }
                    string fileName = img.FileName;
                    string filePath = Path.Combine(_env.WebRootPath, "uploads/img");
                    string fullPath = Path.Combine(filePath, fileName);
                    if(!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create) )
                    {
                        await img.CopyToAsync(stream);
                    }
                    string gPath = @"/uploads/img";
                    string dbPath = Path.Combine(gPath, fileName);
                    product.img = dbPath;

                   
                   //sesuai nama var di model(img)
                    
                    _context.Update(product);
                    _context.SaveChanges(); 
                
                }
                catch(Exception e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete (int id)
        {
            Product product =
            _context.Product.Where (x=> x.Id==id)
                 .FirstOrDefault();
            try 
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}