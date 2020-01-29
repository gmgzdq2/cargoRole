using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class DurumController : Controller
    {
        Models.Context db = new Models.Context();
        // GET: Durum
        public ActionResult Index()
        {
            return View(db.Durum.ToList());
        }
        [Authorize(Roles = "Yönetici,Başkan")]
        public ActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creat(Models.Durum durum)
        {
            Models.Durum _durum = new Models.Durum();
            _durum.Ad = durum.Ad;
            db.Durum.Add(_durum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int Id)
        {
            var durum = db.Durum.Single(y => y.Id == Id);
            return View(durum);
        }
        [HttpPost]
        public ActionResult Update(Models.Durum durum)
        {
            var _durum = db.Durum.Single(y => y.Id == durum.Id);
            _durum.Ad = durum.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult Delete(int Id)
        {
            db.Durum.Remove(db.Durum.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}