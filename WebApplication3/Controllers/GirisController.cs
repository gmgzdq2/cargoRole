using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication3.Controllers
{
    public class GirisController : Controller
    {
         
        // GET: Giris
        Models.Context db = new Models.Context();
        public ActionResult Index()
        {
            
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Models.Kullanici kullanici)
        {
            var giris = db.Kullanici.FirstOrDefault(X => X.Email == kullanici.Email && X.Sifre == kullanici.Sifre);
            if (giris != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.Email, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.IndexError = "Hatalı Email veya Şifre";
               return View();
            }
        }

        public ActionResult Cikis()
        {
            //Session.Clear();
            
            FormsAuthentication.SignOut();
            //Redirect("http://AnotherApplicaton/Giris/Index");
            return RedirectToAction("Index", "Giris");
            //return View();
        }
        

    }
}