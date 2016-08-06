using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using ShopOnline5K.Common;

namespace ShopOnline5K.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int ? page)
        {
            //tạo biến quy đính số sản phẩm trên mỗi trang
            int pagesize = 12;
            //tạo biến số trang
            int pagenumber = (page ?? 1);
            var product_Dao = new ProductDao().ListSP();
            return View(product_Dao.ToPagedList(pagenumber, pagesize));
        }

        [ChildActionOnly]
        public ActionResult Top3Chay()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.TopBanChay(3);
            return PartialView(sp);
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var group_Dao = new GroupProductDao();
            var listcategory = group_Dao.listgroup();
            return PartialView(listcategory);
        }

        public ActionResult ListSP(int ? page)
        {
            //tạo biến quy đính số sản phẩm trên mỗi trang
            int pagesize = 12;
            //tạo biến số trang
            int pagenumber = (page ?? 1);

            var product_Dao = new ProductDao().ListSP();
            return PartialView(product_Dao.ToPagedList(pagenumber,pagesize));
        }


        [ChildActionOnly]
        public ActionResult TopRate()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListProduct(5);
            return PartialView(sp);
        }

        public ActionResult ListSPCategory(int id, int? page)
        {
            //tạo biến quy đính số sản phẩm trên mỗi trang
            int pagesize = 12;
            //tạo biến số trang
            int pagenumber = (page ?? 1);

            var product_Dao = new ProductDao();
            var sp = product_Dao.ListSPCategory(id);
            return View(sp.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult ProductDetail(int id)
        {
            ViewBag.MoreImage = new ProductDao().MoreImage(id);
            var product_Dao = new ProductDao().ViewDetail(id);
            return View(product_Dao);
        }
        public ActionResult ProductRelated(int id)
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListRelatedProducts(id);
            return View(sp);
        }

        [ChildActionOnly]
        public PartialViewResult ProductNew()
        {
            var product_Dao = new ProductDao();
            var sp = product_Dao.ListProduct(12);
            return PartialView(sp);
        }

        public ActionResult ListSPMetatitle(string metatitle, int? page)
        {
            Session[CommonContants.MetaSession] = metatitle;
            //tạo biến quy đính số sản phẩm trên mỗi trang
            int pagesize = 12;
            //tạo biến số trang
            int pagenumber = (page ?? 1);

            var product_Dao = new ProductDao();
            var product = product_Dao.ListSPTagname(metatitle);
            return View(product.ToPagedList(pagenumber, pagesize));
        }

        public ActionResult ListSPMetatitle1(string metatitle, int ? page)
        {
            Session[CommonContants.MetaSession] = metatitle;
            //tạo biến quy đính số sản phẩm trên mỗi trang
            int pagesize = 12;
            //tạo biến số trang
            int pagenumber = (page ?? 1);

            var product_Dao = new ProductDao();
            var product = product_Dao.ListSPTagname1(metatitle);
            return View(product.ToPagedList(pagenumber,pagesize));
        }

        [ChildActionOnly]
        public PartialViewResult ListTag()
        {
            var group_Dao = new GroupProductDao().ListMetatitle();
            return PartialView(group_Dao);
        }
        [ChildActionOnly]
        public PartialViewResult ListTag1()
        {
            var product_Dao = new TagDao().SelectAll();
            return PartialView(product_Dao);
        }

    }
}