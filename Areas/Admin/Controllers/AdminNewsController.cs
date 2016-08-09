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
    public class AdminNewsController : BaseController
    {
        // GET: Admin/AdminNews
        [HasRole(PermissionID = "VIEW_CONTENT")]
        public ActionResult Index()
        {
            var new_Dao = new NewsDao().ListAll();
            return View(new_Dao);
        }
        [HttpGet]
        [HasRole(PermissionID = "ADD_CONTENT")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [HasRole(PermissionID = "ADD_CONTENT")]
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
            return View(news);
        }
        [HasRole(PermissionID = "EDIT_CONTENT")]
        public ActionResult Edit(int id)
        {
            var news_Dao = new NewsDao().ViewDetail(id);
            return View(news_Dao);
        }
        [HttpPost]
        [HasRole(PermissionID = "EDIT_CONTENT")]
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
            return View(news);
        }
        [HasRole(PermissionID = "DELETE_CONTENT")]
        public ActionResult Delete(int id)
        {
            new NewsDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var detail=new NewsDao().ViewDetail(id);
            return View(detail);
        }
    }
}