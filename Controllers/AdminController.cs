using Floral_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Floral_Shop.Controllers
{
    public class AdminController : Controller
    {
        DbfloralshopContext db;
        IWebHostEnvironment env;

        public AdminController(DbfloralshopContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult ViewAllUser()
        {

           var user = db.Users.ToList();
            return View();
        }
    }
}
