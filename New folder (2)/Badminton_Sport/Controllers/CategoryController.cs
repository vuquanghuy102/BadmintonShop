using Badminton_Sport.Models.Data;
using PagedList;
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

        public ViewResult ProductByCategory(string categoryid, int? Page_No)
        {
            int pageSize = 3;
            int pageNumber = (Page_No ?? 1);
            var ct = db.CATEGORies.SqlQuery("Select * from CATEGORY where CATEGORY_ID = '"+categoryid+"'").ToList();
            if (ct == null)
            {
                Response.StatusCode = 404;
                return null;
                //return RedirectToAction("Index", "Product");
            }
            PagedList.IPagedList<PRODUCT> listProduct = db.PRODUCTs.SqlQuery("Select * from PRODUCT where CATEGORY_ID = '"+categoryid+"'").ToList().ToPagedList(pageNumber, pageSize);
            if (listProduct.Count == 0)
            {
                ViewBag.PRODUCT = "Không có sản phẩm nào";
            }
            return View(listProduct);
        }
    }   
}