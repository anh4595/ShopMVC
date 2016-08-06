using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminOrderDetailController : BaseController
    {
        // GET: Admin/AdminOrderDetail
        public ActionResult Index()
        {
            var oder_dao = new OderDetail().ListAll();
            return View(oder_dao);
        }
        public ActionResult Edit(int id)
        {
            var order = new OderDetail().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(ORDERDETAIL order)
        {
            if (ModelState.IsValid)
            {
                var order_Dao = new OderDetail();
                var result = order_Dao.Update(order);
                if (result)
                {
                    return RedirectToAction("Index", "AdminOrderDetail");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thông tin thất bại");
                }
            }
            return View(order);
        }
        public ActionResult Delete(int id)
        {
            new OderDetail().Delete(id);
            return RedirectToAction("Index");
        }
    }
}