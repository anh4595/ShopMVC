using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewNews1()
        {
            var model = new NewsDao().ListAll();
            return PartialView(model);
        }
        public ActionResult NewNews2()
        {
            var model = new NewsDao().ListAll();
            return PartialView(model);
        }
        public ActionResult Thongtin()
        {
            var model = new NewsDao().ListAll();
            return PartialView(model);
        }

        public ActionResult Chitiet(int id)
        {
            var model = new NewsDao().ViewDetail(id);
            return PartialView(model);
        }
        public ActionResult ListTag(string tagname)
        {
            var model = new NewsDao().ListTag(tagname);
            return PartialView(model);
        }
    }
}