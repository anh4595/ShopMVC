using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline5K.Areas.Admin.Models
{
    public class RegisterModel
    {
        [Key]

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150)]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [StringLength(150)]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(150)]
        public string ADDRESS { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(12)]
        public string PHONE { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(150)]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(150)]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage="Không được bỏ trống")]
        public bool status { get; set; }
    }
}