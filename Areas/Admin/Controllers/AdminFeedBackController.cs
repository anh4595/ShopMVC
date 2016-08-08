using Model.DAO;
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
        public ActionResult Index()
        {
            var feedback = new FeedBackDao().ListAll();
            return View(feedback);
        }
        public ActionResult Delete(int id)
        {
            new FeedBackDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}