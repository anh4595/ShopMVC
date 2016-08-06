using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Model.EntityFramework;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminGroupProductController : BaseController
    {
        // GET: Admin/AdminGroupProduct
        public ActionResult Index()
        {
            var group_Dao = new GroupProductDao().ListAll();
            return View(group_Dao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GROUPPRODUCT groupproduct)
        {
            if (ModelState.IsValid)
            {
                var group_dao = new GroupProductDao();
                int count = group_dao.Insert(groupproduct);
                if (count > 0)
                {
                    return RedirectToAction("Index", "AdminGroupProduct");
                }
                else
                {
                    ModelState.AddModelError("","Thêm mới thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var group_Dao = new GroupProductDao().ViewDetail(id);
            return View(group_Dao);
        }
        [HttpPost]
        public ActionResult Edit(GROUPPRODUCT groupproduct)
        {
            if (ModelState.IsValid)
            {
                var group = new GroupProductDao();
                var result = group.Update(groupproduct);
                if (result)
                {
                    return RedirectToAction("Index", "AdminGroupProduct");
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
            new GroupProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}