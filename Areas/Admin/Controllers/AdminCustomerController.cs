using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminCustomerController : BaseController
    {
        // GET: Admin/AdminCustomer
        public ActionResult Index()
        {
            var khachhang_Dao = new KhachHangDao().SelectAll();
            return View(khachhang_Dao);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CUSTOMER customer)
        {
            if (ModelState.IsValid)
            {
                var kh_dao = new KhachHangDao();
                int count = kh_dao.Insert(customer);
                if (count > 0)
                {
                    return RedirectToAction("Index", "AdminCustomer");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thất bại");
                }
            }
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var kh = new KhachHangDao().ViewDetail(id);
            return View(kh);
        }


        [HttpPost]
        public ActionResult Edit(CUSTOMER kh)
        {
            if (ModelState.IsValid)
            {
                var kh_dao = new KhachHangDao();
                var result = kh_dao.Update(kh);
                if (result)
                {
                    return RedirectToAction("Index", "AdminCustomer");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thông tin thất bại");
                }
            }
            return View(kh);
        }

        public ActionResult Delete(int id)
        {
            new KhachHangDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}