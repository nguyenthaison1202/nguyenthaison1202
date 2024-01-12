using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class MenuHinoCarsController : Controller
    {
        private DB_HinoCarEntities1 db = new DB_HinoCarEntities1();

        // GET: Admin/MenuHinoCars
        public ActionResult Index()
        {
            return View(db.MenuHinoCars.ToList());
        }

        // GET: Admin/MenuHinoCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuHinoCar menuHinoCar = db.MenuHinoCars.Find(id);
            if (menuHinoCar == null)
            {
                return HttpNotFound();
            }
            return View(menuHinoCar);
        }

        // GET: Admin/MenuHinoCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuHinoCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nameMenu,link,meta,hide,order")] MenuHinoCar menuHinoCar)
        {
            if (ModelState.IsValid)
            {
                db.MenuHinoCars.Add(menuHinoCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuHinoCar);
        }

        // GET: Admin/MenuHinoCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuHinoCar menuHinoCar = db.MenuHinoCars.Find(id);
            if (menuHinoCar == null)
            {
                return HttpNotFound();
            }
            return View(menuHinoCar);
        }

        // POST: Admin/MenuHinoCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nameMenu,link,meta,hide,order")] MenuHinoCar menuHinoCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuHinoCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuHinoCar);
        }

        // GET: Admin/MenuHinoCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuHinoCar menuHinoCar = db.MenuHinoCars.Find(id);
            if (menuHinoCar == null)
            {
                return HttpNotFound();
            }
            return View(menuHinoCar);
        }

        // POST: Admin/MenuHinoCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuHinoCar menuHinoCar = db.MenuHinoCars.Find(id);
            db.MenuHinoCars.Remove(menuHinoCar);
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
