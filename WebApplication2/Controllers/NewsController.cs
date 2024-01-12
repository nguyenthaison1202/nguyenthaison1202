using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class NewsController : Controller
    {
        DB_HinoCarEntities1 db = new DB_HinoCarEntities1();
        // GET: News
        public ActionResult Index()
        {
            ViewBag.meta = "tin-tuc";
            var v = from t in db.TinTucs
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in db.TinTucs
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}