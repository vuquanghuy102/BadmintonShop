using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Badminton_Sport.Controllers
{
    public class ProductController : Controller
    {
        WebContext db = new WebContext();
        // GET: Product
        public ActionResult Index(int? Page_No)
        {
            int pageSize = 8;
            int pageNumber = (Page_No ?? 1);
            var listProduct = db.PRODUCTs.ToList().ToPagedList(pageNumber, pageSize);
            return PartialView(listProduct);
        }
        public ActionResult Show(string productid="")
        {
            var product = db.PRODUCTs.SqlQuery("SELECT * FROM PRODUCT WHERE PRODUCT_ID = '"+productid+"'").SingleOrDefault();
            if(product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }
        public JsonResult ListName(string q)
        {
            var data = db.PRODUCTs.Where(n => n.PRODUCT_NAME.Contains(q)).Select(n => n.PRODUCT_NAME).ToList();
            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int? Page_No)
        {
            int pageSize = 8;
            int pageNumber = (Page_No ?? 1);
            PagedList.IPagedList<PRODUCT> listProduct = db.PRODUCTs.SqlQuery("Select * from PRODUCT where PRODUCT_NAME like '%"+ keyword + "%'").ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.KeyWord = keyword;
            if(keyword=="")
            {
                ViewBag.NULL = "Không tìm được sản phẩm nào";
            }
            return View(listProduct);
        }
    }
}