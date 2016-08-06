using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminSystemController : BaseController
    {
        // GET: Admin/AdminSystem
        public ActionResult Index()
        {
            var admin_Dao = new AdminDao().SelectAll();
            return View(admin_Dao);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ADMIN admin)
        {
            if (ModelState.IsValid)
            {
                var admin_dao = new AdminDao();
                int count = admin_dao.Insert(admin);
                if (count > 0)
                {
                    return RedirectToAction("Index", "AdminSystem");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thất bại");
                }
            }
            return View(admin);
        }
        public ActionResult Edit(int id)
        {
            var admin = new AdminDao().ViewDetail(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Edit(ADMIN admin)
        {
            if (ModelState.IsValid)
            {
                var admin_dao = new AdminDao();
                var result = admin_dao.Update(admin);
                if (result)
                {
                    return RedirectToAction("Index", "AdminSystem");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thông tin thất bại");
                }
            }
            return View(admin);
        }
        public ActionResult ChangeStatus(int id)
        {
            var result = new AdminDao().ChangeStatus(id);
            return RedirectToAction("Index", "AdminSystem");
        }
        public ActionResult Delete(int id)
        {
            new AdminDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}