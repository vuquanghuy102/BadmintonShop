using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Badminton_Sport.Controllers
{
    public class ProduceController : Controller
    {
        WebContext db = new WebContext();
        // GET: Produce
        public ActionResult ViewProduce()
        {
            return View(db.PRODUCEs.ToList());
        }
        public ActionResult ProductByProduce(string produceid="")
        {
            PRODUCE pd = db.PRODUCEs.SingleOrDefault(n => n.PRODUCE_ID == produceid);
            if (pd == null)
            {
                Response.StatusCode = 404;
                return null;
                //return RedirectToAction("Index", "Product");
            }
            List<PRODUCT> listProduct = db.PRODUCTs.Where(n => n.PRODUCE_ID == produceid).OrderBy(n => n.PRICE).ToList();
            if (listProduct.Count == 0)
            {
                ViewBag.PRODUCE = "Không có sản phẩm nào";
            }
            return View(listProduct);
        }
    }
}