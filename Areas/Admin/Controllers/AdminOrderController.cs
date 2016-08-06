using Model.DAO;
using Model.EntityFramework;
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
        public ActionResult Index()
        {
            var oder_dao = new OderDao().ListAll();
            return View(oder_dao);
        }
        public ActionResult Edit(int id)
        {
            var order = new OderDao().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
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
            return RedirectToAction("Index", "AdminProduct");
        }
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}