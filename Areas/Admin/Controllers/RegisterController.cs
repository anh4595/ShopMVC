using Model.DAO;
using Model.EntityFramework;
using ShopOnline5K.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class RegisterController : BaseController
    {
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var admin = new ADMIN();
            var admin_Dao = new AdminDao();
            if (ModelState.IsValid)
            {
                admin.NAME = model.NAME;
                admin.ADDRESS = model.ADDRESS;
                admin.EMAIL = model.EMAIL;
                admin.PHONE = model.PHONE;
                admin.USERNAME = model.USERNAME;
                admin.PASSWORD = model.PASSWORD;
                admin.STATUS = model.status;
                int id = admin_Dao.Insert(admin);
                if (id > 0)
                {
                    ModelState.AddModelError("", "Đăng ký thành công");
                    return RedirectToAction("", "SbAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng kí không thành công");
                }

            }
            return Redirect("index");
        }

    }
}