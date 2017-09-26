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
        private readonly DataLogger logger;

        public HomeController()
        {
            logger = new DataLogger();
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
            var userDataList = GetUserDataFromSession();
            userDataList.Add(userData);
            Session["Data for users"] = userDataList;
            return View();
        }

        [HttpPost]
        public ActionResult UserDataLog()
        {
            List<UserDataModel> dataToLog = GetUserDataFromSession();
            if (dataToLog.Any())
            {
                logger.Log(dataToLog);
                Session.Clear();                
            } 
            
            return View("UserDataInput");
        }

        #region Helper methods          
            private List<UserDataModel> GetUserDataFromSession()
            {
                return (List<UserDataModel>)Session["Data for users"] ?? new List<UserDataModel>();
            }        
        #endregion
    }
}