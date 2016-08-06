using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminSlideController : BaseController
    {
        // GET: Admin/AdminSlide
        public ActionResult Index()
        {
            var slide_Dao = new SlideDao().ListAll();
            return View(slide_Dao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var slide_Dao = new SlideDao().ViewDetail(id);
            return View(slide_Dao);
        }
        [HttpPost]
        public ActionResult Create(SLIDE slide)
        {
            if (ModelState.IsValid)
            {
                var slide_Dao = new SlideDao();
                int id = slide_Dao.Insert(slide);
                if (id > 0)
                {
                    return RedirectToAction("Index", "AdminSlide");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới slide thât bại");
                }
            }
            return View(slide);
        }
        [HttpPost]
        public ActionResult Edit(SLIDE slide)
        {
            if (ModelState.IsValid)
            {
                var slide_Dao = new SlideDao();
                var result = slide_Dao.Update(slide);
                if (result)
                {
                    return RedirectToAction("Index", "AdminSlide");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thất bại");
                }
            }
            return View(slide);
        }

        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}