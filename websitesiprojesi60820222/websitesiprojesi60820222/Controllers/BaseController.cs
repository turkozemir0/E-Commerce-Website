using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websitesiprojesi60820222.Models;

namespace websitesiprojesi60820222.Controllers
{
    public class BaseController : Controller
    {
        
        // GET: Base
        public BaseController()
        {
            iakademi43gunceldbEntities db = new iakademi43gunceldbEntities();
            ViewBag.kategorilistesi = db.tbl_Categories.ToList();
            ViewBag.markalistesi = db.tbl_Suppliers.ToList();
            ViewBag.sayfadakiurunsayisi = db.tbl_Settings.FirstOrDefault(s => s.ID == 1).sayfadakiurunsayisi;
            ViewBag.telefon = db.tbl_Settings.FirstOrDefault(s => s.ID == 1).telefon;
            ViewBag.anasayfadakiurunsayisi = db.tbl_Settings.FirstOrDefault(s => s.ID == 1).anasayfadakiurunsayisi;
        }
    }
}