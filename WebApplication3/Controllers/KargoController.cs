using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Models.Context db = new Models.Context();
        
        public ActionResult Index()
        {
            return View(db.Kargo.Include("Kargocu").Include("Urun").Include("Durum").ToList());
        }
        [Authorize(Roles = "Yönetici,Başkan")]
        public ActionResult Creat()
        {
            //dfgdfgdfgdg
            var kargocuList = db.Kargocu.ToList();
            ViewData["Kargocu"] = kargocuList;
            
            var UrunList = db.Urun.ToList();
            ViewData["Urun"] = UrunList;
            
            var DurumList = db.Durum.ToList();
            ViewData["Durum"] = DurumList;
           
            return View();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int KargocuId, int UrunId, int DurumID)
        {
            Models.Kargo _kargo = new Models.Kargo();
            _kargo.SonIslemTarihi = DateTime.Now;
            _kargo.KargocuId =KargocuId ;
            _kargo.UrunId = UrunId;
            _kargo.DurumID = DurumID;           
            db.Kargo.Add(_kargo);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Update(int Id)
        {
            var kargo = db.Kargo.Single(x => x.Id == Id);
            var kargocuList = db.Kargocu.ToList();
            ViewData["Kargocu"] = kargocuList;

            var UrunList = db.Urun.ToList();
            ViewData["Urun"] = UrunList;

            var DurumList = db.Durum.ToList();
            ViewData["Durum"] = DurumList;

            
            return View(kargo);
        }
        [HttpPost]
        public ActionResult Update(Models.Kargo kargo)
        {
            var _kargo = db.Kargo.Single(x => x.Id == kargo.Id);
            _kargo.KargocuId = kargo.KargocuId;
            _kargo.UrunId = kargo.UrunId;
            _kargo.DurumID = kargo.DurumID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            db.Kargo.Remove(db.Kargo.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}