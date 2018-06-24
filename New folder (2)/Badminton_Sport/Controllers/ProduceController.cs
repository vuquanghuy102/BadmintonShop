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
            var pd = db.PRODUCEs.SqlQuery("Select * from PRODUCE where PRODUCE_ID = '"+produceid+"'").ToList();
            if (pd == null)
            {
                Response.StatusCode = 404;
                return null;
                //return RedirectToAction("Index", "Product");
            }
            List<PRODUCT> listProduct = db.PRODUCTs.SqlQuery("Select * from PRODUCT where PRODUCE_ID = '"+produceid+"' order by PRICE" ).ToList();
            if (listProduct.Count == 0)
            {
                ViewBag.PRODUCE = "Không có sản phẩm nào";
            }
            return View(listProduct);
        }
    }
}