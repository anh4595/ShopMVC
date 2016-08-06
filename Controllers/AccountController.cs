using Model.DAO;
using Model.EntityFramework;
using ShopOnline5K.Common;
using ShopOnline5K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var khachhang_Dao = new KhachHangDao();
                var result = khachhang_Dao.CheckLogin(model.username, model.password);
                if (result)
                {
                    var user = khachhang_Dao.GetID(model.username);
                    var usersession = new UserLogin();
                    usersession.userID = user.CUSTOMERS_ID;
                    usersession.userName = user.NAME;
                    usersession.address = user.ADDRESS;
                    usersession.email = user.MAIL;
                    usersession.phone = user.PHONE;
                    Session.Add(CommonContants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu đăng nhập không chính xác");
                }
            }
            return View("Index");

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var khachhang = new CUSTOMER();
            var khachhang_Dao = new KhachHangDao();
            if (ModelState.IsValid)
            {
                var result = khachhang_Dao.CheckUser(model.username, model.email);
                if (result)
                {
                    ModelState.AddModelError("", "Tài khoản đăng nhặp hoặc email đã tồn tại");
                }
                else
                {
                    khachhang.NAME = model.name;
                    khachhang.MAIL = model.email;
                    khachhang.PHONE = model.phone;
                    khachhang.ADDRESS = model.adress;
                    khachhang.USERNAME = model.username;
                    khachhang.PASSWORD = model.password;
                    int count = khachhang_Dao.Insert(khachhang);
                    if (count > 0)
                    {
                        ModelState.AddModelError("", "Đăng kí thành công");
                        return RedirectToAction("Login", "Account");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Exit()
        {
            Session[CommonContants.USER_SESSION] = null;
            return RedirectToAction("index", "Home");
        }
    }
}