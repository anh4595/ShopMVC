using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminNewsController : BaseController
    {
        // GET: Admin/AdminNews
        public ActionResult Index()
        {
            var new_Dao = new NewsDao().ListAll();
            return View(new_Dao);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NEWS news)
        {
            if (ModelState.IsValid)
            {
                var news_Dao = new NewsDao();
                news.CREATEDAY = DateTime.Now;
                int count = news_Dao.Insert(news);
                if (count > 0)
                {
                    return RedirectToAction("Index", "AdminNews");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var news_Dao = new NewsDao().ViewDetail(id);
            return View(news_Dao);
        }
        [HttpPost]
        public ActionResult Edit(NEWS news)
        {
            if (ModelState.IsValid)
            {
                var news_Dao = new NewsDao();
                var result = news_Dao.Update(news);
                if (result)
                {
                    return RedirectToAction("Index", "AdminNews");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thông tin thất bại");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new NewsDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}