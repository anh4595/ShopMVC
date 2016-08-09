using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Model.EntityFramework;
using ShopOnline5K.Common;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminProductController : BaseController
    {
        // GET: Admin/AdminProduct
        [HasRole(PermissionID = "VIEW_PRODUCT")]
        public ActionResult Index()
        {
            var product_Dao = new ProductDao().ListSP();
            return View(product_Dao);
        }
        [HttpGet]
        [HasRole(PermissionID = "ADD_PRODUCT")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [HasRole(PermissionID = "ADD_PRODUCT")]
        public ActionResult Create(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                var product_dao = new ProductDao();
                product.CREATED_DATE = DateTime.Now;
                int count = product_dao.Insert(product);
                if (count > 0)
                {
                    return RedirectToAction("Index", "AdminProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thất bại");
                }
            }
            return View(product);
        }
        [HasRole(PermissionID = "EDIT_PRODUCT")]
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        [HttpPost]
        [HasRole(PermissionID = "EDIT_PRODUCT")]
        public ActionResult Edit(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                var product_dao = new ProductDao();
                var result = product_dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "AdminProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thông tin thất bại");
                }
            }
            return View(product);
        }
        public ActionResult ChangeStatus(int id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return RedirectToAction("Index", "AdminProduct");
        }
        [HasRole(PermissionID = "DELETE_PRODUCT")]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var detail = new ProductDao().ViewDetail(id);
            return View(detail);
        }
    }
}