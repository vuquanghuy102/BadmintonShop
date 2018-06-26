using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Badminton_Sport.Models
{
   
    public class BillDao
    {
        WebContext db = null;
        public BillDao()
        {
            db = new WebContext();
        }
        public string Insert(BILL bill)
        {
            db.BILLs.Add(bill);
            db.SaveChanges();
            return bill.BILL_ID;
        }
    }
}