using ShopOnline5K.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class SbAdminController : BaseController
    {
        // GET: Admin/SbAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Exit()
        {
            Session[CommonContants.USER_SESSION] = null;
            return RedirectToAction("index", "SbAdmin");
        }
       
    }
}