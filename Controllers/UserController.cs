using Floral_Shop.Models;
using Floral_Shop.Models.viewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace Floral_Shop.Controllers
{
    public class UserController : Controller
    {
        DbfloralshopContext db;
        IWebHostEnvironment env;

        public UserController(DbfloralshopContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }


        public IActionResult registerUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult registerUser(UserViewModel user)
        {

            var filename = "";


            if (ModelState.IsValid)
            {

                var folder = Path.Combine(env.WebRootPath, "images");


               // filename = Guid.NewGuid().ToString() + "_" + user.Picture.FileName;
               //filename = Guid.NewGuid().ToString() + "_" + Path.GetFileName(user.Picture.FileName);
              // var filepath = Path.Combine(folder, filename);
              // user.Picture.CopyTo(new FileStream(filepath, FileMode.Create));

               

                User u = new User()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    Role = "User",
                    Address = user.Address,
                    Phone = user.Phone,
                   
                };

                var hashpasword = new PasswordHasher<User>();
                var encryptpassword = hashpasword.HashPassword(null, user.Password);

                db.Users.Add(u);
                    db.SaveChanges();

                    return RedirectToAction("index", "Home");
                }
                return View();
            }
        }
    }



    
