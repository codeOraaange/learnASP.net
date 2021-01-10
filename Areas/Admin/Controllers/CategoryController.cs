using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sportstore.Models;
using sportstore.Helper;


using Microsoft.AspNetCore.Authorization;

namespace sportstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class CategoryController : Controller
    {
        readonly Context _context;

        public CategoryController (Context context)
        {
            _context = context; 
        }
       public IActionResult Index (int? pageNumber)
        {
            int pageSize = 3;

            IQueryable<Category>data=
                _context.Category;

            var result = PaginationHelper<Category>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );
            // List<Product> products = 
            //     _context.Product.ToList();
            return View(result);
        }

        
        //tambah lagi

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            [Bind("Name")]Category category
        )
        {
            if(ModelState.IsValid){
                try
                {
                    _context.Add(category);
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
            Category category =
            _context.Category.Where(x => x.Id == id)
            .FirstOrDefault();
            return View (category);
        }
        [HttpPost]
        public IActionResult Edit(
            [Bind("Id","Name")]Category category
        )
        {
            if(ModelState.IsValid){
                try
                {
                    _context.Update(category);
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
            Category category =
            _context.Category.Where (x=> x.Id==id)
            .FirstOrDefault();
            if (category==null)
            {
                return NotFound();
            }
            try 
            {
                _context.Remove(category);
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