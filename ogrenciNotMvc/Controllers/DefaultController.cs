using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ogrenciNotMvc.Models.EntityFramework;

namespace ogrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        MvcOkulEntities db = new MvcOkulEntities();
        // GET: Default
        public ActionResult Index()
        {
            var dersler = default(List<TableDersler>);
            using (var db = new MvcOkulEntities())
            {
                dersler = db.TableDersler.ToList();
            }
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKayit(TableDersler p)   
        {
            
            db.TableDersler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

            var def = db.TableDersler.Find(id);
            db.TableDersler.Remove(def);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dersget(int id)
        {
            var def = db.TableDersler.Find(id);
            return View("Dersget", def);
        }
        public ActionResult Guncelle(TableDersler p)
        {
            var drs = db.TableDersler.Find(p.dersID);
            drs.dersAd = p.dersAd;  
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }


    }
}