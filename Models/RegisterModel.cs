using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string name { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu đăng nhập không được để trống")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string repassword { get; set; }

        [Required(ErrorMessage = "Điện thoại liên lạc không được để trống")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Email liên lạc không được để trống")]
        public string email { get; set; }

        [Required(ErrorMessage = "Địa chỉ liên lạc không được để trống")]
        public string adress { get; set; }
    }
}