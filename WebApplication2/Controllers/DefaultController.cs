using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        DB_HinoCarEntities1 db = new DB_HinoCarEntities1();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getProduct(string meta)
        {
            ViewBag.meta = "san-pham";
            var v = from t in db.SanPhams
                    where t.meta == meta && t.hide == true
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getCategory()
        {
            ViewBag.meta = "san-pham";
            var v = from t in db.DanhMucs
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getNews()
        {
            ViewBag.meta = "tin-tuc";
            var v = from t in db.TinTucs
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}