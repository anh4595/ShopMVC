using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}