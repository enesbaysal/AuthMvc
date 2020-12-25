using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ogrenciNotMvc.Models.EntityFramework;
using ogrenciNotMvc.Models;

namespace ogrenciNotMvc.Controllers
{
    public class NotController : Controller
    {
        // GET: Not
        MvcOkulEntities db = new MvcOkulEntities();

        public ActionResult Index()
        {
            var not = db.TableNotlar.ToList();
            return View(not);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TableNotlar p)
        {
            db.TableNotlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Sil(int id)
        //{
        //    var nott = db.TableNotlar.Find(id);
        //    db.TableNotlar.Remove(nott);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult NotGet(int id)
        {
            var nott = db.TableNotlar.Find(id);
            return View("NotGet", nott);
        }


        public ActionResult Guncelle(TableNotlar p)
        {
            var nt = db.TableNotlar.Find(p.notID);
            nt.Sinav1 = p.Sinav1;
            nt.Sinav2 = p.Sinav2;
            nt.Sinav3 = p.Sinav3;
            nt.Proje = p.Proje;
            nt.Durum = p.Durum;
            db.SaveChanges();
            return RedirectToAction("Index", "Not");
        }




    }


    }

