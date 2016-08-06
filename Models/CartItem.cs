using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Models
{
    public class CartItem
    {
        public PRODUCT product { get; set; }
        public int soluong { get; set; }
    }
}