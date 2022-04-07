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
    public class UserController : Controller
    {
        private readonly NWClothingCoDbContext _db;
        private readonly UserManager<NWClothingCoUser> _userManager;

        public UserController(NWClothingCoDbContext db, UserManager<NWClothingCoUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View(GetAccountHelper("INDEX"));
        }

        // for editing customer information
        public IActionResult CustomerInfo()
        {
            ViewBag.AccountHelper = GetAccountHelper("CUSTOMER_INFO");
            return View(GetCustomer());
        }

        // for editing customer information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerInfo(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var c = GetCustomer();
                c.Address_Line1 = customer.Address_Line1;
                c.Address_Line2 = customer.Address_Line2;
                c.City = customer.City;
                c.State = customer.State;
                c.PostalCode = customer.PostalCode;

                _db.Customer.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(customer);
        }

        public IActionResult CustomerOrders() 
        {
            var customer = GetCustomer();
            var orders = _db.Order.Where(o => o.Customer_Id == customer.Customer_Id).ToList();

            ViewBag.CustomerOrders = orders;

            return View(GetAccountHelper("CUSTOMER_ORDERS"));
        }


        // Customer Not Found Page
        public IActionResult AddCustomerToAccount() 
        {            
            return View();
        }

        // creates customer if one does not already exist within the account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomerToAccount(Customer customer) 
        {
            if (ModelState.IsValid) 
            {
                Customer c = customer;
                c.User_Id = _userManager.GetUserId(HttpContext.User);

                _db.Customer.Add(c);
                _db.SaveChanges();
                return RedirectToAction("Cart", "Store");
            }

            return View();
        }


        // helper methods
        public Customer GetCustomer()
        {
            Customer customer = _db.Customer.Where(c => c.User_Id == _userManager.GetUserId(HttpContext.User)).SingleOrDefault();
            return customer;
        }

        public AccountHelper GetAccountHelper(string p) 
        {
            var user = _db.Users.Find(_userManager.GetUserId(HttpContext.User));
            var userRole = _db.UserRoles.Where(u => u.UserId == user.Id).SingleOrDefault();

            Customer customer = GetCustomer();
            var page = p;
            var role = (_db.Roles.Where(ur => ur.Id == userRole.RoleId).SingleOrDefault()).NormalizedName;
            var firstName = user.FirstName;
            var lastName = user.LastName;

            return new AccountHelper(customer, page, role, firstName, lastName);
        }
    }
}
