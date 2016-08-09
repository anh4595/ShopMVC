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
    public class AdminOrderController : BaseController
    {
        // GET: Admin/AdminOrder
        [HasRole(PermissionID = "VIEW_ORDER")]
        public ActionResult Index()
        {
            var oder_dao = new OderDao().ListAll();
            return View(oder_dao);
        }
        [HasRole(PermissionID = "EDIT_ORDER")]
        public ActionResult Edit(int id)
        {
            var order = new OderDao().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
        [HasRole(PermissionID = "EDIT_ORDER")]
        public ActionResult Edit(ORDER order)
        {
            if (ModelState.IsValid)
            {
                var order_Dao = new OderDao();
                var result = order_Dao.Update(order);
                if (result)
                {
                    return RedirectToAction("Index", "AdminOrder");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thông tin thất bại");
                }
            }
            return View(order);
        }
        public ActionResult ChangeStatus(int id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return RedirectToAction("Index", "AdminOrder");
        }
        [HasRole(PermissionID = "DELETE_ORDER")]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}