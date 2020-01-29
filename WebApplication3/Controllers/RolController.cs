using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class RolController : Controller
    {
        Models.Context db = new Models.Context();

        // GET: Rol
        [Authorize(Roles = "Yönetici,Başkan")]
        public ActionResult Index()
        {
            return View(db.Rol.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Rol rol)
        {
            Models.Rol _rol = new Models.Rol();
            _rol.Ad = rol.Ad;
            db.Rol.Add(_rol);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int Id)
        {
            var rol = db.Rol.Single(y => y.Id == Id);
            return View(rol);
        }
        [HttpPost]
        public ActionResult Update(Models.Rol rol)
        {
            var _rol = db.Rol.Single(y => y.Id == rol.Id);
            _rol.Ad = rol.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int Id)
        {
            db.Rol.Remove(db.Rol.Single(x => x.Id == Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}  
     