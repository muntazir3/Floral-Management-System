using System.Diagnostics;
using Floral_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Floral_Shop.Helpers;  // Make sure to use the SessionExtensions methods

namespace Floral_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbfloralshopContext db;

        public HomeController(ILogger<HomeController> logger, DbfloralshopContext db)
        {
            _logger = logger;
            this.db = db;
        }

        // Index page where products are displayed
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult about()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult bouquet()
        {
            return View();
        }

        public IActionResult birthday()
        {
            return View();
        }

        public IActionResult anniversary()
        {
            return View();
        }

        public IActionResult wedding()
        {
            return View();
        }

        public IActionResult valentine()
        {
            return View();
        }

        public IActionResult congratulation()
        {
            return View();
        }

        public IActionResult cart()
        {
            // Retrieve cart from session and send it to the view
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        public IActionResult checkout()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult myaccount()
        {
            return View();
        }

        public IActionResult wishlist()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(db.Users.ToList());
        }

        // Cart page where cart items are displayed
        public IActionResult Cart()
        {
            // Retrieve the cart from the session (or create an empty cart if it's not found)
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart); // Send the cart to the Cart.cshtml page
        }

        // Add product to the cart
        [HttpPost]
        public JsonResult AddToCart(int bouquetId, int quantity)
        {
            // Retrieve product details from the database
            var bouquet = db.Bouquets.FirstOrDefault(b => b.BouquetId == bouquetId);
            if (bouquet == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            // Retrieve the cart from the session or create a new one if not found
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Check if the product is already in the cart
            var existingItem = cart.FirstOrDefault(c => c.BouquetId == bouquetId);
            if (existingItem != null)
            {
                // If product exists, update quantity and total price
                existingItem.Quantity += quantity;
                
            }
            else
            {
                // Add new product to the cart
                cart.Add(new CartItem
                {
                    BouquetId = bouquetId,
                    Name = bouquet.Name,
                    Price = bouquet.Price,
                    Image = bouquet.Image,
                    Quantity = quantity,
                   
                });
            }

            // Save the updated cart in session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, message = "Product added to cart." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
