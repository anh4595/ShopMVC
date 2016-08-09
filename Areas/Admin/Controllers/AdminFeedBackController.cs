using Model.DAO;
using ShopOnline5K.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminFeedBackController : BaseController
    {
        // GET: Admin/AdminFeedBack

        [HasRole(PermissionID = "VIEW_FEEDBACK")]
        public ActionResult Index()
        {
            var feedback = new FeedBackDao().ListAll();
            return View(feedback);
        }

        [HasRole(PermissionID = "DELETE_FEEDBACK")]
        public ActionResult Delete(int id)
        {
            new FeedBackDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}