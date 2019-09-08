using CustomerReading.Bussiness;
using CustomerReading.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerReading.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepo userRepo;

        public LoginController(UserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new UserLogin(); 
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserLogin model) {
            if (ModelState.IsValid)
            {
                userRepo.UserLogin(model);
                return RedirectToAction("Index", "Home");
            }
              return View(model);
        }


       
    }
}