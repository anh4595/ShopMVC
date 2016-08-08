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
                var result = admin_dao.CheckLogin(model.username, model.password, true);
                if (result == 1)
                {
                    var user = admin_dao.GetID(model.username);
                    var usersession = new UserLogin();
                    usersession.userID = user.ADMIN_ID;
                    usersession.userName = user.NAME;
                    usersession.group_id = user.GROUP_ID;
                    var listrole = admin_dao.GetlistRole(model.username);
                    Session.Add(CommonContants.SESSION_ROLE, listrole);
                    Session.Add(CommonContants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "SbAdmin");
                }
                else
                    if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    else
                        if (result == -1)
                        {
                            ModelState.AddModelError("", "Tài khoản đang bị khóa");
                        }
                        else
                            if (result == -2)
                            {
                                ModelState.AddModelError("", "Mật khẩu đăng nhập không chính xác");
                            }
                            else
                                if (result == -3)
                                {
                                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập");
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Đăng nhập không chính xác");
                                }
            }
            return Redirect("Index");
        }
    }
}