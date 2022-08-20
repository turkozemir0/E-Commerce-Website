using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websitesiprojesi60820222.Models;

namespace websitesiprojesi60820222.Controllers
{
    public class AdminController : Controller
    {
        iakademi43gunceldbEntities db = new iakademi43gunceldbEntities();
        // GET: Admin
        public ActionResult AnaSayfa()
        {
            return View();
        }

        public ActionResult kategorikaydet()
        {
            List<tbl_Categories> catlist = db.tbl_Categories.ToList();
            ViewData["catlist"] = catlist.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });
            return View();
        }
        [HttpPost]

        public ActionResult kategorikaydet(tbl_Categories cat)
        {
            bool sonuc = cls_Categories.kategorikontrol(cat.CategoryName.ToLower());
            if (sonuc==false)
            {
                if (cat.CategoryID == 0)
                {
                    cat.ParentID = 0;
                }
                else
                {
                    cat.ParentID = cat.CategoryID;
                }
                cat.Active = true;
                db.tbl_Categories.Add(cat);
            }
            else
            {
                Session["Mesaj"] = "Bu kategori zaten kayıtlı.";
            }
            return RedirectToAction("kategorikaydet");
        }

        public ActionResult markakaydet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult markakaydet(tbl_Suppliers sup,HttpPostedFileBase fileuploader)
        {
            sup.PhotoPath = fileuploader.FileName;
            sup.Active = true;
            db.tbl_Suppliers.Add(sup);
            db.SaveChanges();
            return View();

        }

        public ActionResult urunkaydet()
        {

            List<tbl_Suppliers> suplist = db.tbl_Suppliers.ToList();
            List<tbl_Categories> catlist = db.tbl_Categories.ToList();
            List<tbl_Status> statlist = db.tbl_Status.ToList();
            ViewData["suplist"] = suplist.Select(s => new SelectListItem { Text = s.BrandName, Value = s.SupplierID.ToString() });
            ViewData["catlist"] = catlist.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.CategoryID.ToString() });
            ViewData["statlist"] = statlist.Select(ss => new SelectListItem { Text = ss.adi, Value = ss.statusID.ToString() });
            return View();
        }
        [HttpPost]
        public ActionResult urunkaydet(tbl_Products product,HttpPostedFileBase fileuploader)
        {
            if (product.Discount ==null)
            {
                product.Discount = 0;
            }
            if (product.Keywords==null)
            {
                product.Keywords = "";
            }
            if (product.Notes == null)
            {
                product.Notes = "";
            }
            product.Active = true;
            product.AddDate = DateTime.Now;
            product.OneCikanlar = 0;
            product.CokSatanlar = 0;
            
            db.tbl_Products.Add(product);
            db.SaveChanges();
            
            return RedirectToAction("urunkaydet");
        }
       
        public ActionResult ayarlarkaydet()
        {
            return View();         
        }
        [HttpPost]
        public ActionResult ayarlarkaydet(tbl_Settings set)
        {
            bool sonuc = cls_Settings.ayarlarkaydet(set);
            if (sonuc==true)
            {
                Session["Mesaj"] = "ayarlar başarıyla kaydedildi";
                return RedirectToAction("AnaSayfa");
            }
            else
            {
                Session["Mesaj"] = "ayarlar kaydedilemedi";
            }

            return View();
        }
     
    }
}