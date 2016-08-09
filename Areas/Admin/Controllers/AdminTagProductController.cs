using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminTagProductController : BaseController
    {
        // GET: Admin/AdminTagProduct
        public ActionResult Index()
        {
            var tag_Dao = new TagDao().SelectAll();
            return View(tag_Dao);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tag_Dao = new TagDao().ViewDetail(id);
            return View(tag_Dao);
        }
        [HttpPost]
        public ActionResult Create(TAG tag)
        {
            if (ModelState.IsValid)
            {
                var tag_Dao = new TagDao();
                int id = tag_Dao.Insert(tag);
                if (id > 0)
                {
                    return RedirectToAction("Index", "AdminTagProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới slide thât bại");
                }
            }
            return View(tag);
        }
        [HttpPost]
        public ActionResult Edit(TAG tag)
        {
            if (ModelState.IsValid)
            {
                var tag_Dao = new TagDao();
                var result = tag_Dao.Update(tag);
                if (result)
                {
                    return RedirectToAction("Index", "AdminTagProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thất bại");
                }
            }
            return View(tag);
        }

        public ActionResult Delete(int id)
        {
            new TagDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}