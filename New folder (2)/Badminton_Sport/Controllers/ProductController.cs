using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Badminton_Sport.Controllers
{
    public class ProductController : Controller
    {
        WebContext db = new WebContext();
        // GET: Product
        public PartialViewResult Index()
        {
            var listProduct = db.PRODUCTs.ToList();
            return PartialView(listProduct);
        }
        public ActionResult Show(string productid="")
        {
            PRODUCT product = db.PRODUCTs.SingleOrDefault(n => n.PRODUCT_ID == productid);
            if(product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }
    }
}