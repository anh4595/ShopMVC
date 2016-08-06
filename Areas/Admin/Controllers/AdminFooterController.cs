using Model.DAO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Areas.Admin.Controllers
{
    public class AdminFooterController : BaseController
    {
        // GET: Admin/AdminFooter
        public ActionResult Index()
        {
            var company_Dao = new CompanyDao().ListAll();
            return View(company_Dao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company_Dao = new CompanyDao().ViewDetail(id);
            return View(company_Dao);
        }
        [HttpPost]
        public ActionResult Create(COMPANY slide)
        {
            if (ModelState.IsValid)
            {
                var company_Dao = new CompanyDao();
                int id = company_Dao.Insert(slide);
                if (id > 0)
                {
                    return RedirectToAction("Index", "AdminFooter");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới slide thât bại");
                }
            }
            return View(slide);
        }
        [HttpPost]
        public ActionResult Edit(COMPANY slide)
        {
            if (ModelState.IsValid)
            {
                var company_Dao = new CompanyDao();
                var result = company_Dao.Update(slide);
                if (result)
                {
                    return RedirectToAction("Index", "AdminFooter");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa/Cập nhật thất bại");
                }
            }
            return View(slide);
        }

        public ActionResult Delete(int id)
        {
            new CompanyDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}