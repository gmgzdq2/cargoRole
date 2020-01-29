using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class KargoSirketiController : Controller
    {
        // GET: KargoSirketi
        Models.Context db = new Models.Context();
        [Authorize(Roles = "Yönetici,Başkan")]
        public ActionResult Index()
        {
            return View(db.KargoSirketi.ToList());
        }
        
        public ActionResult Creat()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Creat(Models.KargoSirketi kargoSirketi)
        {

            Models.KargoSirketi _kargoSirketi = new Models.KargoSirketi();
            _kargoSirketi.Ad = kargoSirketi.Ad;
            _kargoSirketi.VergiNo = kargoSirketi.VergiNo;
            db.KargoSirketi.Add(_kargoSirketi);
            db.SaveChanges();
            
         
            return RedirectToAction("Index");
            
        }
        public ActionResult Delete(int Id)
        {
            db.KargoSirketi.Remove(db.KargoSirketi.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int Id)
        {
            var kargoSirketi = db.KargoSirketi.Single(x => x.Id == Id);
            return View(kargoSirketi);
        }
        [HttpPost]
        public ActionResult Update(Models.KargoSirketi kargoSirketi)
        {
            var _kargoSirketi = db.KargoSirketi.Single(x => x.Id == kargoSirketi.Id);
            _kargoSirketi.Ad = kargoSirketi.Ad;
            _kargoSirketi.VergiNo = kargoSirketi.VergiNo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}