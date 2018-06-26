using Badminton_Sport.Models;
using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Badminton_Sport.Controllers
{
    public class CartController : Controller
    {
        WebContext db = new WebContext();
        private const string CartSession = "CartSession";
        // GET: CartItem
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            double tongTien = 0;
            foreach(var item in list)
            {
                tongTien += item.Quantity * item.Product.PRICE;
            }
            ViewBag.TotalMoney = tongTien.ToString();
            return View(list);
        }
        //Xoá tất cả sản phẩm ajax
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        //Xoá từng sản phẩm
        public JsonResult Delete(string productID)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(n => n.Product.PRODUCT_ID == productID);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        //dùng ajax
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(n => n.Product.PRODUCT_ID == item.Product.PRODUCT_ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(string productID, int quantity)
        {
            PRODUCT pd = db.PRODUCTs.Find(productID);
            var product = pd;
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(n=>n.Product.PRODUCT_ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.PRODUCT_ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
                
            }
            else
            {
                // tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                // gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {
            if(Session["userId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var bill = new BILL();
                var getbill = db.BILLs.ToList().LastOrDefault();
                if (getbill == null)
                {
                    bill.BILL_ID = "B_01";
                }
                else
                {
                    int b = int.Parse(getbill.BILL_ID.Substring(2));
                    b++;
                    if (b < 10)
                    {
                        bill.BILL_ID = "B_0" + b.ToString();
                    }
                    else
                    {
                        bill.BILL_ID = "B_" + b.ToString();
                    }
                }
                bill.DATE_BUY = DateTime.Now;
                bill.STT = false;
                bill.USER_ID = Session["userId"].ToString();

                var id = new BillDao().Insert(bill);
                var cart = (List<CartItem>)Session[CartSession];
                foreach (var item in cart)
                {
                    var billDetail = new BILL_DETAIL();
                    billDetail.BILL_ID = id;
                    billDetail.PRODUCT_ID = item.Product.PRODUCT_ID;
                    billDetail.QUANTITY = item.Quantity;
                    billDetail.TOTAL = item.Quantity * item.Product.PRICE;
                    var detailDao = new BillDetailDao().Insert(billDetail);
                }
            }
            return View();
        }
    }
}