using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ogrenciNotMvc.Models.EntityFramework;
using ogrenciNotMvc.Controllers;
using System.Web.Security;

namespace ogrenciNotMvc.Controllers
{
    public class GirisController : Controller
    {

        MvcOkulEntities db = new MvcOkulEntities();

        public ActionResult Giris()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Giris(TableAdmin p)
        {

            var log = db.TableAdmin.FirstOrDefault(m => m.kulAd == p.kulAd && m.sifre == p.sifre);
            if (log!=null)
            {
                FormsAuthentication.SetAuthCookie(log.kulAd, false);
                return RedirectToAction("Index", "Ogrenci");
            }
            else
            {
                ViewBag.mesaj = "Hatalı İşlem Yaptınız";
                return View();
            }
            
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris","Giris");
        }
    }
}