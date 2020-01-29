using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
   
    public class KullaniciController : Controller
    {
        Models.Context db = new Models.Context();
        //CRUD Create,Read,Update,Delete
        // GET: Kullanici
        [Authorize(Roles = "Yönetici")]
        public ActionResult Index()
        {
            
            return View(db.Kullanici.Include("Rol").ToList());
        }
        public ActionResult Create()
        {
            var rolList = db.Rol.ToList();
            ViewData["Rol"] = rolList;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int rolId, string Tc, string Ad, string Soyad, string Email,string Sifre)
        {
            Models.Kullanici _kullanici = new Models.Kullanici();
            _kullanici.Ad = Ad;
            _kullanici.Soyad = Soyad;
            _kullanici.TcNo = Tc;
            _kullanici.Email = Email;
            _kullanici.Sifre = Sifre;
            _kullanici.RolId = rolId;
            db.Kullanici.Add(_kullanici);
            db.SaveChanges();
            return RedirectToAction("Index","Giris");
        }
        
        public ActionResult Update(int Id)
        {
            var kullanici = db.Kullanici.Single(x => x.Id == Id);
            return View(kullanici);

        }
        [HttpPost]
        public ActionResult Update(Models.Kullanici kullanici)
        {
            var _kullanici = db.Kullanici.Single(x => x.Id == kullanici.Id);
            _kullanici.Ad = kullanici.Ad;
            _kullanici.Soyad = kullanici.Soyad;
            _kullanici.TcNo = kullanici.TcNo;            
            _kullanici.Email = kullanici.Email;
            _kullanici.Sifre = kullanici.Sifre;           

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            db.Kullanici.Remove(db.Kullanici.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
