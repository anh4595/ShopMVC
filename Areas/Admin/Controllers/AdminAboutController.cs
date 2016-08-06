using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: Admin/AdminAbout
        public ActionResult Index()
        {
            var about_Dao = new AboutDao().ListAll();
            return View(about_Dao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var about_Dao = new AboutDao().ViewDetail(id);
            return View(about_Dao);
        }
        [HttpPost]
        public ActionResult Create(ABOUT about)
        {
            if (ModelState.IsValid)
            {
                var about_Dao = new AboutDao();
                int id = about_Dao.Insert(about);
                if (id > 0)
                {
                    return RedirectToAction("Index", "AdminAbout");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới slide thât bại");
                }
            }
            return View(about);
        }
        [HttpPost]
        public ActionResult Edit(ABOUT about)
        {
            if (ModelState.IsValid)
            {
                var about_Dao = new AboutDao();
                var result = about_Dao.Update(about);
                if (result)
                {
                    return RedirectToAction("Index", "AdminAbout");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thất bại");
                }
            }
            return View(about);
        }

        public ActionResult Delete(int id)
        {
            new AboutDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}