using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProcessor;

namespace WebInterface.Controllers
{
    public class HomeController : Controller
    {
        private IUserStorage storage;

        public HomeController()
        {
            storage = new FileUserDataStorage();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult UserDataInput()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult UserDataInput(UserDataModel userData)
        {
            storage.Save(userData);
            return View();
        }
    }
}