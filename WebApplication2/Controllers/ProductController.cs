using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        DB_HinoCarEntities1 db = new DB_HinoCarEntities1();
        // GET: Product
        public ActionResult Index(string meta)
        {
            var v = from t in db.DanhMucs
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in db.SanPhams
                    where t.ID == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}