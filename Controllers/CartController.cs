using Common;
using Model.DAO;
using Model.EntityFramework;
using ShopOnline5K.Common;
using ShopOnline5K.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopOnline5K.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.PRODUCT_ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.product.PRODUCT_ID == productId)
                        {
                            item.soluong += quantity;
                            CommonContants.QuantityOld = item.soluong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.product = product;
                    item.soluong = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.product = product;
                item.soluong = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            if (Session[CommonContants.USER_SESSION] == null || Session[CommonContants.USER_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(FormCollection collection)
        {
            var cart = (List<CartItem>)Session[CartSession];
            decimal total = 0;
            var session = (UserLogin)Session[CommonContants.USER_SESSION];
            var oder = new ORDER();
            oder.CUSTOMERS_ID = session.userID;
            oder.CREATED_DATE = DateTime.Now;
            oder.STATUS = false;

            foreach (var item in cart)
            {
                total += (item.product.DISCOUNT_PRICE.GetValueOrDefault(0) * item.soluong);
            }
            oder.TOTAL_MONEY = total;
            try
            {
                var id = new OderDao().Insert(oder);
                var detailDao = new OderDetail();

                foreach (var item in cart)
                {
                    var orderDetail = new ORDERDETAIL();
                    orderDetail.PRODUCT_ID = item.product.PRODUCT_ID;
                    orderDetail.ORDER_ID = id;
                    orderDetail.PRICE = (decimal)item.product.DISCOUNT_PRICE;
                    orderDetail.QUANTITY = item.soluong;
                    detailDao.CheckInsert(orderDetail);
                }

                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/controller/neworder.html"));

                content = content.Replace("{{CustomerName}}", session.userName);
                content = content.Replace("{{Phone}}", session.phone);
                content = content.Replace("{{Email}}", session.email);
                content = content.Replace("{{Address}}", session.address);
                content = content.Replace("{{Total}}", "$" + total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(session.email, "Đơn hàng mới từ ShopOnline5K", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ ShopOnline5K", content);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            Session[CartSession] = null;
            return RedirectToAction("Suscess", "Cart");
        }

        public ActionResult Suscess()
        {
            return View();
        }

        public ActionResult Delete(int productId)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                list.RemoveAll(x => x.product.PRODUCT_ID == productId);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index", "Cart");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.PRODUCT_ID == item.product.PRODUCT_ID);
                if (jsonItem != null)
                {
                    item.soluong = jsonItem.soluong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult DeleteAll()
        {
            Session[CartSession] = null;
            return RedirectToAction("index", "Cart");
        }

    }
}