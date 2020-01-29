using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class KargocuController : Controller
    {
       
        // GET: Kargocu
        Models.Context db = new Models.Context();
        [Authorize(Roles = "Yönetici,Başkan")]
        public ActionResult Index()
        {
            
            var a = this.Session.SessionID;
            
                return View(db.Kargocu.ToList());

            
        }
         
        public ActionResult Create()
        {
            var kargoSirketiList = db.KargoSirketi.ToList();
            ViewData["KargoSirketi"] = kargoSirketiList;

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int kargoSirketiId, string Tc, string Ad, string Soyad, string Tel)
        {
            Models.Kargocu _kargocu = new Models.Kargocu();
            _kargocu.Ad = Ad;
            _kargocu.Soyad = Soyad;
            _kargocu.TcNo = Tc;
            _kargocu.TelNo = Tel;
            _kargocu.KargoSirketiId = kargoSirketiId;
            db.Kargocu.Add(_kargocu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int Id)
        {
            var kargocu = db.Kargocu.Single(x => x.Id == Id);
            return View(kargocu);
        }
        [HttpPost]
        public ActionResult Update(Models.Kargocu kargocu)
        {
            var _kargocu = db.Kargocu.Single(x => x.Id == kargocu.Id);
            _kargocu.Ad = kargocu.Ad;
            _kargocu.Soyad = kargocu.Soyad;
            _kargocu.TcNo = kargocu.TcNo;
            _kargocu.TelNo = kargocu.TelNo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            db.Kargocu.Remove(db.Kargocu.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
