using Model.DAO;
using Model.EntityFramework;
using ShopOnline5K.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminGroupController : Controller
    {
        // GET: Admin/AdminGroup
        [HasRole(PermissionID = "VIEW_USER")]
        public ActionResult Index()
        {
            var gradmin_dao = new AdminGroupDao().SelectAll();
            return View(gradmin_dao);
        }

        [HttpGet]
        [HasRole(PermissionID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [HasRole(PermissionID = "EDIT_USER")]
        public ActionResult Edit(string id)
        {
            var gradmin_dao = new AdminGroupDao().ViewDetail(id);
            return View(gradmin_dao);
        }
        [HttpPost]
        [HasRole(PermissionID = "ADD_USER")]
        public ActionResult Create(ADMINGROUP gradmin)
        {
            if (ModelState.IsValid)
            {
                var gradmin_dao = new AdminGroupDao();
                string id = gradmin_dao.Insert(gradmin);
                if (id != null)
                {
                    return RedirectToAction("Index", "AdminGroup");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới slide thât bại");
                }
            }
            return View(gradmin);
        }
        [HttpPost]
        [HasRole(PermissionID = "EDIT_USER")]
        public ActionResult Edit(ADMINGROUP gradmin)
        {
            if (ModelState.IsValid)
            {
                var gradmin_dao = new AdminGroupDao();
                var result = gradmin_dao.Update(gradmin);
                if (result)
                {
                    return RedirectToAction("Index", "AdminGroup");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thất bại");
                }
            }
            return View(gradmin);
        }
        [HasRole(PermissionID = "DELETE_USER")]
        public ActionResult Delete(string id)
        {
            new AdminGroupDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}