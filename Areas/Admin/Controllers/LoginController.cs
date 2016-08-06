using Model.DAO;
using ShopOnline5K.Areas.Admin.Models;
using ShopOnline5K.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var admin_dao = new AdminDao();
                var result = admin_dao.CheckLogin(model.username, model.password);
                if (result)
                {
                    var user = admin_dao.GetID(model.username);
                    var usersession = new UserLogin();
                    usersession.userID = user.ADMIN_ID;
                    usersession.userName = user.NAME;
                    Session.Add(CommonContants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "SbAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu đăng nhập không chính xác");
                }
            }
            return Redirect("Index");
        }
    }
}