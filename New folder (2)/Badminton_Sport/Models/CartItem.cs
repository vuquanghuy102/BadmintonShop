using Badminton_Sport.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Badminton_Sport.Models
{
    [Serializable]
    public class CartItem
    {
        public PRODUCT Product { get; set; }
        public int Quantity { get; set; }
    }
}