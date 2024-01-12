using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class TinTucsController : Controller
    {
        private DB_HinoCarEntities1 db = new DB_HinoCarEntities1();

        // GET: Admin/TinTucs
        public ActionResult Index()
        {
            return View(db.TinTucs.ToList());
        }

        // GET: Admin/TinTucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,img1,des1,link,detail1,meta,hide,order,datebegin,img2,img3,des2,des3,detail2,detail3")] TinTuc tinTuc, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/AssetsAdmin/upload/img/tintuc"), filename);
                        img.SaveAs(path);
                        tinTuc.img1 = filename; //Lưu ý
                    }
                    else
                    {
                        tinTuc.img1 = "package-1.jpg";
                    }
                    tinTuc.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    tinTuc.meta = tinTuc.meta; //convert Tiếng Việt không dấu
                    db.TinTucs.Add(tinTuc);
                    db.SaveChanges();
                    return RedirectToAction("Index", "TinTucs");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,img1,des1,link,detail1,meta,hide,order,datebegin,img2,img3,des2,des3,detail2,detail3")] TinTuc tinTuc, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                TinTuc temp = db.TinTucs.Find(tinTuc.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/AssetsAdmin/upload/img/tintuc"), filename);
                        img.SaveAs(path);
                        temp.img1 = filename; //Lưu ý

                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.name = tinTuc.name;
                    temp.des1= tinTuc.des1;
                    temp.des2= tinTuc.des2;
                    temp.des3= tinTuc.des3;
                    temp.detail1= tinTuc.detail1;
                    temp.detail2 = tinTuc.detail2;
                    temp.detail3= tinTuc.detail3;
                    temp.meta = tinTuc.meta; //convert Tiếng Việt không dấu
                    temp.hide = tinTuc.hide;
                    temp.order = tinTuc.order;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "TinTucs");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(tinTuc);
        }

        public TinTuc getById(long id)
        {
            return db.TinTucs.Where(x => x.id == id).FirstOrDefault();
        }


        // GET: Admin/TinTucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
