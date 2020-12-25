    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ogrenciNotMvc.Models.EntityFramework;

namespace ogrenciNotMvc.Controllers
{

    [Authorize]
    public class OgrenciController : Controller
    {

      
        // GET: Ogrenci
        MvcOkulEntities db = new MvcOkulEntities();

        
        public ActionResult Index()
        {
            var ogrenci = default(List<TableOgrenciler>);
            using (var db = new MvcOkulEntities())
            {
                ogrenci = db.TableOgrenciler.ToList();
            }
            return View(ogrenci);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from m in db.TableKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = m.kulupAd,
                                                 Value = m.kulupID.ToString()
                                             }

                                           ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TableOgrenciler p)
        {
            var klp = db.TableKulupler.Where(m => m.kulupID == p.TableKulupler.kulupID).FirstOrDefault();
            p.TableKulupler = klp;
            db.TableOgrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");    
        }
        public ActionResult Sil(int id)
        {

            var og = db.TableOgrenciler.Find(id);
            db.TableOgrenciler.Remove(og);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

        public ActionResult OgrenciGet(int id)
        {
            var ogr = db.TableOgrenciler.Find(id);
            return View("OgrenciGet", ogr);
        }
        public ActionResult Guncelle(TableOgrenciler p)
        {
            var og = db.TableOgrenciler.Find(p.ogrID);
            og.ogrAd = p.ogrAd;
            og.ogrSoyad = p.ogrSoyad;
            og.ogrCinsiyet = p.ogrCinsiyet;
            og.ogrKulup = p.ogrKulup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }

    }
}