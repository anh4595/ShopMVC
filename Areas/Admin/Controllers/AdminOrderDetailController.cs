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
    public class AdminOrderDetailController : BaseController
    {
        // GET: Admin/AdminOrderDetail
        [HasRole(PermissionID = "VIEW_ORDERDETAIL")]
        public ActionResult Index()
        {
            var oder_dao = new OderDetail().ListAll();
            return View(oder_dao);
        }
        [HasRole(PermissionID = "EDIT_ORDERDETAIL")]
        public ActionResult Edit(int id)
        {
            var order = new OderDetail().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
        [HasRole(PermissionID = "EDIT_ORDERDETAIL")]
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
        [HasRole(PermissionID = "DELETE_ORDERDETAIL")]
        public ActionResult Delete(int id)
        {
            new OderDetail().Delete(id);
            return RedirectToAction("Index");
        }
    }
}