using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Badminton_Sport.Models
{
    public class BillDetailDao
    {
        WebContext db = null;
        public BillDetailDao()
        {
            db = new WebContext();
        }
        public bool Insert(BILL_DETAIL detail)
        {
            try
            {
                db.BILL_DETAIL.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}