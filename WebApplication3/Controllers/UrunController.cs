using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Models.Context db = new Models.Context();
        public ActionResult Index()
        {
            return View(db.Urun.ToList());
        }
        public ActionResult Creat()
        {
            return View();  
        }
        [HttpPost]
        
        public ActionResult Creat(Models.Urun urun)
        {

            Models.Urun _urun = new Models.Urun();

            _urun.Ad = urun.Ad;
            db.Urun.Add(_urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            var urun = db.Urun.Single(x => x.Id == Id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult Update(Models.Urun urun)
        {
            var _urun = db.Urun.Single(x => x.Id == urun.Id);
            _urun.Ad = urun.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            db.Urun.Remove(db.Urun.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}