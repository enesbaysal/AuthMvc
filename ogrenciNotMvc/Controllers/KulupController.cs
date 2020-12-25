using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ogrenciNotMvc.Models.EntityFramework;

namespace ogrenciNotMvc.Controllers
{
    
    public class KulupController : Controller
    {
        // GET: Kulup
        MvcOkulEntities db = new MvcOkulEntities();

        public ActionResult Index()
        {
            var kulup = default(List<TableKulupler>);
            using (var db = new MvcOkulEntities())
            {
                kulup = db.TableKulupler.ToList();
            }
            return View(kulup);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TableKulupler p)
        {
            db.TableKulupler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {

            var kulup = db.TableKulupler.Find(id);
            db.TableKulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kulupget(int id)
        {
            var kulup = db.TableKulupler.Find(id);
            return View("kulupget",kulup);
        }

        public ActionResult Guncelle(TableKulupler p)
        {
            var klp = db.TableKulupler.Find(p.kulupID);
            klp.kulupAd = p.kulupAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulup");
        }

    }
}