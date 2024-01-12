using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    public class TempController : Controller
    {
        // GET: Temp
        DB_HinoCarEntities1 db = new DB_HinoCarEntities1();
        public ActionResult getMenu()
        {
            var v = from t in db.MenuHinoCars
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getDanhMucSanPham()
        {
            ViewBag.meta = "san-pham";
            var v = from t in db.DanhMucs
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}