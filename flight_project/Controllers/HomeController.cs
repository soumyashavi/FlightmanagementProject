using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flight_project.Models;

namespace flight_project.Controllers
{
   
    public class HomeController : Controller
    {
        FlightEntities db = new FlightEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
        

            return View();
        }
         public ActionResult Register( Registration tb)
        {
      


            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(Registration tb)
        {
            var check = db.Registrations.Where(x => x.UserName.Equals(tb.UserName) && x.Password.Equals(tb.Password)).FirstOrDefault();
           
            if (check != null)
            {
                Session["Username"] = tb.UserName.ToString();
                Session["Password"] = tb.Password.ToString();

                ViewBag.user = tb.UserName.ToString();
                return RedirectToAction("WelcomeUser");
            }
            else
            {
                Response.Write("Invalid Username or password!!!");
            }

            return View();

        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(admin1 tb1)
        {
            FlightEntities1 db1 = new FlightEntities1();
            var check = db1.admin1.Where(x => x.Name.Equals(tb1.Name) && x.Password.Equals(tb1.Password)).FirstOrDefault();
            if (check != null)
            {
                Session["Username"] = tb1.Name.ToString();
                Session["Password"] = tb1.Password.ToString();
                ViewBag.name = Session["Username"];

                return RedirectToAction("index");
            }
            else
            {
                Response.Write("Invalid Username or password!!!");
            }

            return View();

        }
        public ActionResult WelcomeAdmin()
        {
            return View();
        }
        public ActionResult WelcomeUser()
        {
            return View();
        }





    }
}