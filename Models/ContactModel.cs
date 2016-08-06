using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string name { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        public string email { get; set; }

        [Required(ErrorMessage = "Thông tin phan hồi không được để trống")]
        public string detail { get; set; }
        public DateTime createday { get; set; }

    }
}