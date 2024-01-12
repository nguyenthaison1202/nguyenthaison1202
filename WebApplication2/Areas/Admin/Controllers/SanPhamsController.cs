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
    public class SanPhamsController : Controller
    {
        private DB_HinoCarEntities1 db = new DB_HinoCarEntities1();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,nameCar,trongtai,dongco,kichthuocthung,baohanh,hide,order,meta,datebegin,img,kltoanbo,klbanthan,sochongoi,thungnhienlieu,DxRxC,chieudaicoso,vetbanhxe,khoangcachtruc,tendongco,loaidongco,tieuchuankhithai,dungtichxylanh,congsuatcucdai,momen,hopso,loainhieulieu,phanhtruoc,phanhsau,phanhdong,soluonglop,lop")] SanPham sanPham, HttpPostedFileBase img)
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
                        path = Path.Combine(Server.MapPath("~/AssetsAdmin/upload/img/product"), filename);
                        img.SaveAs(path);
                        sanPham.img = filename; //Lưu ý
                    }
                    else
                    {
                        sanPham.img = "package-1.jpg";
                    }

                    sanPham.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    sanPham.meta = sanPham.meta; //convert Tiếng Việt không dấu
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index", "SanPhams");
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

            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,nameCar,trongtai,dongco,kichthuocthung,baohanh,hide,order,meta,datebegin,img,kltoanbo,klbanthan,sochongoi,thungnhienlieu,DxRxC,chieudaicoso,vetbanhxe,khoangcachtruc,tendongco,loaidongco,tieuchuankhithai,dungtichxylanh,congsuatcucdai,momen,hopso,loainhieulieu,phanhtruoc,phanhsau,phanhdong,soluonglop,lop")] SanPham sanPham, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                SanPham temp = getById(sanPham.ID);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/AssetsAdmin/upload/img/product"), filename);
                        img.SaveAs(path);
                        temp.img = filename; //Lưu ý

                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.nameCar = sanPham.nameCar;
                    temp.kichthuocthung = sanPham.kichthuocthung;
                    temp.trongtai = sanPham.trongtai;
                    temp.dongco = sanPham.dongco;
                    temp.baohanh = sanPham.baohanh;
                    temp.datebegin = sanPham.datebegin;
                    temp.kltoanbo = sanPham.kltoanbo;
                    temp.klbanthan = sanPham.klbanthan;

                    temp.sochongoi = sanPham.sochongoi;
                    temp.thungnhienlieu = sanPham.thungnhienlieu;
                    temp.DxRxC = sanPham.DxRxC;
                    temp.chieudaicoso = sanPham.chieudaicoso;
                    temp.vetbanhxe = sanPham.vetbanhxe;
                    temp.khoangcachtruc = sanPham.khoangcachtruc;

                    temp.tendongco = sanPham.tendongco;
                    temp.loaidongco = sanPham.loaidongco;
                    temp.tieuchuankhithai = sanPham.tieuchuankhithai;
                    temp.dungtichxylanh = sanPham.dungtichxylanh;
                    temp.congsuatcucdai = sanPham.congsuatcucdai;
                    temp.momen = sanPham.momen;

                    temp.hopso = sanPham.hopso;
                    temp.loainhieulieu = sanPham.loainhieulieu;
                    temp.phanhtruoc = sanPham.phanhtruoc;
                    temp.phanhsau = sanPham.phanhsau;
                    temp.phanhdong = sanPham.phanhdong;
                    temp.soluonglop = sanPham.soluonglop;
                    temp.lop = sanPham.lop;

                    temp.meta = sanPham.meta; //convert Tiếng Việt không dấu
                    temp.hide = sanPham.hide;
                    temp.order = sanPham.order;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "SanPhams");
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
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
        public SanPham getById(long id)
        {
            return db.SanPhams.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
