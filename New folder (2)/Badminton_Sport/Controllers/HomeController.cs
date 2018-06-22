
using Badminton_Sport.Models.BusinessModels;
using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Badminton_Sport.Controllers
{
    public class HomeController : Controller
    {
        WebContext db = new WebContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string passwordMD5 = Common.EncryptMD5( password);
            var user = db.USERS.SingleOrDefault(x => x.USERNAME == username && x.PASSWORD == password);
            if(user != null && user.ISADMIN == 1)
            {
                Session["userId"] = user.USER_ID;
                Session["userName"] = user.USERNAME;
                Session["pass"] = user.PASSWORD;
                Session["avatar"] = user.AVARTA;
                Session["isAdmin"] = user.ISADMIN;
                return RedirectToAction("Index","Admin/Home");
            }
            else if (user != null && user.ISADMIN == 0)
            {
                Session["userId"] = user.USER_ID;
                Session["userName"] = user.USERNAME;
                Session["pass"] = user.PASSWORD;
                Session["avatar"] = user.AVARTA;
                Session["isAdmin"] = user.ISADMIN;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Bạn đã đăng nhập sai username hoặc password !!";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Manual()
        {
            return View();
        }
    }
}