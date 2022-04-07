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
    public class StoreController : Controller
    {
        private readonly NWClothingCoDbContext _db;
        private readonly UserManager<NWClothingCoUser> _userManager;

        public StoreController(NWClothingCoDbContext db, UserManager<NWClothingCoUser> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Product;
            return View(productList);
        }

        //PRODUCT DETAILS
        public IActionResult ProductDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();    
            }

            var product = _db.Product.Find(id);
            if (product == null) 
            {
                return NotFound();
            }

            return View(product);
        }

        // Cart
        public IActionResult Cart(int? id)
        {
            // check to make sure there is a customer row associated with the user account
            var customer = GetCustomer();

            // check if there is a customer associated with the account
            if (customer == null)
            {
                return RedirectToAction("AddCustomerToAccount", "User");
            }

            // get the user cart
            var user_cart = GetCart(customer);

            // List to hold cart Items
            List<CartItem> cartItems = new List<CartItem>();

            // Cheack if the product id is null
            // this is for displaying the cart without adding a product
            if (id == null || id == 0)
            {
                // get the cart details for the users cart
                var ucd = _db.Cart_Details
                    .Where(ct_d => ct_d.Cart_Id == user_cart.Cart_Id)
                    .ToArray();

                // if there are no cart details for the users cart
                // return the cart with an empty cartItems list
                if (ucd == null) 
                {
                    return View(cartItems);
                }

                // if there are items in the user cart
                // then add cart items to the llist based off the cart details
                foreach (CartDetails cd in ucd)
                {
                    Product p = _db.Product.Find(cd.Product_Id);

                    cartItems.Add(new CartItem(
                        p.Image_Name_1,
                        p.Product_Name,
                        cd.Quantity,
                        p.Price
                    ));
                }

                // pass the cartItems list to the view
                return View(cartItems);
            }


            /*------------------- THIS IS IF WE ARE ADDING A SPECIFIC PRODUCT TO THE USER CART -----------------------------*/

            // returns not found if there is no product associated with the ID
            var product = _db.Product.Find(id);

            // check to see if the item being added to the cart already exists in the users cart
            var c_d = _db.Cart_Details
                .Where(ctd => ctd.Product_Id == product.Product_Id)
                .Where(ctd => ctd.Cart_Id == user_cart.Cart_Id)
                .SingleOrDefault();

            if (c_d != null) // if the item is in the users cart, update the quantity of that item.
            {
                c_d.Quantity++;
                _db.SaveChanges();
            }
            else { // if not, then add the item to the users cart
                // creates cartDetails object to be added to the list and the database
                CartDetails cartDetails = new CartDetails();
                cartDetails.Cart_Id = user_cart.Cart_Id;
                cartDetails.Product_Id = product.Product_Id;
                cartDetails.Quantity = 1; // change this to make sure it takes in quantity form element
                cartDetails.Date_Added = DateTime.Now;

                _db.Cart_Details.Add(cartDetails);
                _db.SaveChanges();
            }

            // get all of the cart details that already exist in the users cart
            var user_cart_details = _db.Cart_Details
                .Where(ctd => ctd.Cart_Id == user_cart.Cart_Id)
                .ToArray();

            foreach (CartDetails cd in user_cart_details)
            {
                Product p = _db.Product.Find(cd.Product_Id);

                cartItems.Add(new CartItem(
                    p.Image_Name_1,
                    p.Product_Name,
                    cd.Quantity,
                    p.Price
                ));
            }

            // pass the cartItems list to the view
            return View(cartItems);


        }

        // deletes items from cart, then redirects back to the cart page
        public IActionResult DeleteCartDetails(string name) 
        {
            // get the product, customer, and user cart
            var product = _db.Product.Where(p => p.Product_Name == name).SingleOrDefault();
            var customer = GetCustomer();
            var user_cart = GetCart(customer);

            // check if that product exists
            if (product == null) 
            {
               return RedirectToAction("Cart", null);
            }

            // retrieve the cart details 
            var cart_details = _db.Cart_Details
                .Where(cd => cd.Cart_Id == user_cart.Cart_Id)
                .Where(cd => cd.Product_Id == product.Product_Id)
                .SingleOrDefault();

            _db.Cart_Details.Remove(cart_details);
            _db.SaveChanges();

            return RedirectToAction("Cart", null);
        }

        // increases the quantity of selected item in the users cart
        public IActionResult IncreaseQuantity(string name)
        {
            var product = _db.Product.Where(p => p.Product_Name == name).SingleOrDefault();
            var customer = GetCustomer();
            var user_cart = GetCart(customer);

            if (product == null)
            {
                return RedirectToAction("Cart", null);
            }

            var cart_details = _db.Cart_Details
                .Where(cd => cd.Cart_Id == user_cart.Cart_Id)
                .Where(cd => cd.Product_Id == product.Product_Id)
                .SingleOrDefault();

            cart_details.Quantity++;
            _db.SaveChanges();

            return RedirectToAction("Cart", null);

        }

        // decrease the quantity of selected item in the users cart
        public IActionResult DecreaseQuantity(string name)
        {
            var product = _db.Product.Where(p => p.Product_Name == name).SingleOrDefault();
            var customer = GetCustomer();
            var user_cart = GetCart(customer);

            if (product == null)
            {
                return RedirectToAction("Cart", null);
            }

            var cart_details = _db.Cart_Details
                .Where(cd => cd.Cart_Id == user_cart.Cart_Id)
                .Where(cd => cd.Product_Id == product.Product_Id)
                .SingleOrDefault();

            cart_details.Quantity--;
            _db.SaveChanges();

            return RedirectToAction("Cart", null);
        }

        // adds records to Order and OrderDetails tables
        // deletes cart records when user orders the products in their cart
        public IActionResult PlaceOrder()
        {
            var customer = GetCustomer();
            var cart = GetCart(customer);
            var cart_details = GetCart_Details(cart.Cart_Id);

            float total = 0;
            foreach (var cd in cart_details) 
            {
                var product = _db.Product.Find(cd.Product_Id);
                total += (float)(product.Price * cd.Quantity);
            }
                

            Order order = new Order();
            order.Order_No = Guid.NewGuid().ToString();
            order.Order_Date = DateTime.Now;
            order.Order_Total = total;
            order.Customer_Id = customer.Customer_Id;
            order.Is_Delivered = false;

            _db.Order.Add(order);
            _db.SaveChanges();

            var customer_order = _db.Order.Where(o => o.Order_No == order.Order_No).SingleOrDefault();
            foreach (var cd in cart_details) 
            {
                var product = _db.Product.Find(cd.Product_Id);

                Order_Details od = new Order_Details();
                od.Product_Id = cd.Product_Id;
                od.Product_Qty = cd.Quantity;
                od.Product_Price = (float)product.Price;
                od.Item_total = (float)(product.Price * cd.Quantity);
                od.Order_Id = customer_order.Oder_Id;

                _db.Order_Details.Add(od);
                _db.Cart_Details.Remove(cd);
                _db.SaveChanges();
            }

            _db.Cart.Remove(cart);
            _db.SaveChanges();

            return View();
        }


        // helper methods
        public Customer GetCustomer() 
        {
            Customer customer = _db.Customer.Where(c => c.User_Id == _userManager.GetUserId(HttpContext.User)).SingleOrDefault();
            return customer;
        }

        public Cart GetCart(Customer customer) 
        {
            Cart ct = _db.Cart.Where(ct => ct.Customer_Id == customer.Customer_Id).SingleOrDefault();

            if (ct == null)
            {
                Cart cart = new Cart();
                cart.Cart_No = Guid.NewGuid().ToString();
                cart.Customer_Id = customer.Customer_Id;
                cart.DateCreated = DateTime.Now;
                cart.CartEpirationDate = DateTime.Now.AddDays(7);

                // add cart and cart details to database
                _db.Cart.Add(cart);
                _db.SaveChanges();

                ct = _db.Cart.Where(c => c.Customer_Id == customer.Customer_Id).SingleOrDefault();

                return ct;
            }
            else {
                return ct;
            }              
        }

        public CartDetails[] GetCart_Details(int cart_id)
        {
            CartDetails[] cartDetails = _db.Cart_Details.Where(cd => cd.Cart_Id == cart_id).ToArray();
            return cartDetails;
        }
    }
}
