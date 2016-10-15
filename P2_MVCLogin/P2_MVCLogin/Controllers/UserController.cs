using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace P2_MVCLogin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();        
        }
        [HttpPost]
        public ActionResult LogIn(Models.UserModel user)
        {
            if (ModelState.IsValid) 
            {
                if (Isvalid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Incorrecto");
                }
            }
            return View(user);
        }
        public ActionResult Registration() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Models.UserModel user) 
        {
            if (ModelState.IsValid)
            {
                using (var db = new MainDBContext())
                {
                    var sysUser = db.SystemUser.Create();
                    sysUser.Email = user.Email;
                    sysUser.Password = user.Password;
                    sysUser.PasswordSalt = user.Password;
                    sysUser.UserId = Guid.NewGuid();

                    db.SystemUser.Add(sysUser);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Incorrecto");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool Isvalid(string Email, string password) 
        {
            bool Isvalid = false;
            using (var db = new MainDBContext())
            {
                var user = db.SystemUser.FirstOrDefault(u => u.Email == Email);
                if (user != null) 
                {
                    if (user.Password == password)
                    {
                        Isvalid = true;
                    }
                }
            }
            return Isvalid;
        }
    }
}
