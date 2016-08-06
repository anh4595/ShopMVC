using Model.DAO;
using Model.EntityFramework;
using ShopOnline5K.Common;
using ShopOnline5K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline5K.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Slide()
        {
            var slide_Dao = new SlideDao().ListAll1();
            return PartialView(slide_Dao);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var company_Dao = new CompanyDao().ListAll();
            return PartialView(company_Dao);
        }
        public ActionResult Group()
        {
            var group_Dao = new GroupProductDao();
            var listgoup = group_Dao.listgroup();
            return View(listgoup);
        }

        public ActionResult ProductNavigation()
        {
            var group_Dao = new GroupProductDao();
            var product_navigation = group_Dao.listgroup();
            return View(product_navigation);
        }
        public ActionResult ShowProductIndex()
        {
            var group_Dao = new GroupProductDao();
            var product_Dao = new ProductDao();
            var product_show = product_Dao.ListProduct(12);
            return View(product_show);
        }

        [ChildActionOnly]
        public PartialViewResult TopMenu()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCar()
        {
            var cart = Session[CommonContants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public PartialViewResult ShowProductDienTu()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListSPDienTu();
            return PartialView(sp);
        }
        [ChildActionOnly]
        public PartialViewResult ShowProductNgehNhin()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListSPNgheNhin();
            return PartialView(sp);
        }
        [ChildActionOnly]
        public PartialViewResult ShowProductGiaDung()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListSPGiaDung();
            return PartialView(sp);
        }
        [ChildActionOnly]
        public PartialViewResult ShowProductXeCo()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListSPXeCo();
            return PartialView(sp);
        }
        [ChildActionOnly]
        public PartialViewResult ShowProductSach()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListSPSachBao();
            return PartialView(sp);
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupID();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult MMenuCProduct()
        {
            var model = new GroupProductDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult ChildMenu(int parentId)
        {
            var model = new GroupProductDao().ListByParentId(parentId);
            ViewBag.ListCategory = new GroupProductDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult LastPost()
        {
            var new_Dao = new NewsDao().LatsPost(3);
            return PartialView(new_Dao);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var contact = new CONTACT();
            var contact_Dao = new ContacDao();
            if (ModelState.IsValid)
            {
                contact.NAME = model.name;
                contact.MAIL = model.email;
                contact.CREATED_DATE = DateTime.Now;
                contact.PHONE = model.phone;
                contact.DETAIL = model.detail;
                contact.ADDRESS = model.address;
                contact.COMPANY = model.company;
                int count = contact_Dao.Insert(contact);
                if (count > 0)
                {
                    return RedirectToAction("Contact","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Gửi phẩn hồi không thành công");
                }
            }
            return View(model);
        }
            

    }
}
