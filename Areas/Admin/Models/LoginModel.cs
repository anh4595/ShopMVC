using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản đăng nhập")]
        public string username { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu đăng nhập")]
        public string password { get; set; }
    }
}