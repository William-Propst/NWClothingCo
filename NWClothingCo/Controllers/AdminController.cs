using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NWClothingCo.Areas.Identity.Data;
using NWClothingCo.Data;
using NWClothingCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Controllers
{
    public class AdminController : Controller
    {
        private readonly NWClothingCoDbContext _db;
        private readonly UserManager<NWClothingCoUser> _userManager;

        public AdminController(NWClothingCoDbContext db, UserManager<NWClothingCoUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductManagement()
        {
            IEnumerable<Product> productsList = _db.Product;
            IEnumerable<Category> categoriesList = _db.Category;
            ViewBag.products = productsList;
            ViewBag.categories = categoriesList;
            return View();   
        }

        //public IActionResult ProductManagement(Product obj) 
        //{
        //    if (ModelState.IsValid)
        //    { 
        //        var product =  
        //    }
        //}
    }
}
