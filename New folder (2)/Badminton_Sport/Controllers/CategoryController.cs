using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Badminton_Sport.Controllers
{
    public class CategoryController : Controller
    {
        WebContext db = new WebContext();
        // GET: Category
        public ActionResult ViewCategory()
        {
            return View(db.CATEGORies.ToList());
        }

        public ViewResult ProductByCategory(string categoryid = "")
        {
            CATEGORY ct = db.CATEGORies.SingleOrDefault(n => n.CATEGORY_ID == categoryid);
            if (ct == null)
            {
                Response.StatusCode = 404;
                return null;
                //return RedirectToAction("Index", "Product");
            }
            List<PRODUCT> listProduct = db.PRODUCTs.Where(n => n.CATEGORY_ID == categoryid).OrderBy(n => n.PRICE).ToList();
            if (listProduct.Count == 0)
            {
                ViewBag.PRODUCT = "Không có sản phẩm nào";
            }
            return View(listProduct);
        }
    }   
}