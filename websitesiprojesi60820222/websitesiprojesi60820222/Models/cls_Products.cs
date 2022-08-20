using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websitesiprojesi60820222.Models
{
    public class cls_Products
    {
        iakademi43gunceldbEntities db = new iakademi43gunceldbEntities();
        public static int sayfadakiurunsayisi = 0;
        public static int anasayfadakiurunsayisi = 0;

        public List<vw_urunler>urunlergetir(string urunler,string hangisayfa,int sayfano)
        {
            List<vw_urunler> liste = null;

            if (hangisayfa =="anasayfa")
            {
                if (urunler=="yeni")
                {
                    liste = db.vw_urunler.OrderByDescending(u => u.AddDate).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="slider")
                {
                    liste = db.vw_urunler.Where(u => u.statusID == 2).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="ozel")
                {
                    liste = db.vw_urunler.Where(u => u.statusID == 3).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="indirim")
                {
                    liste = db.vw_urunler.Where(u => u.Discount > 0).OrderByDescending(u => u.Discount).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="onecikanlar")
                {
                    liste = db.vw_urunler.OrderByDescending(u => u.OneCikanlar).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="coksatanlar")
                {
                    liste = db.vw_urunler.OrderByDescending(u => u.CokSatanlar).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="firsat")
                {
                    liste = db.vw_urunler.Where(u => u.statusID == 4).Take(anasayfadakiurunsayisi).ToList();
                }
                else if (urunler=="yildiz")
                {
                    liste = db.vw_urunler.Where(u => u.statusID == 5).Take(anasayfadakiurunsayisi).ToList();
                }
               

                
                
            }
            else
            {
                if (urunler=="yeni")
                {
                    if (sayfano==0)
                    {
                        liste = db.vw_urunler.OrderByDescending(u => u.AddDate).Take(sayfadakiurunsayisi).ToList();
                    }
                }
                if (urunler=="ozel")
                {
                    if (sayfano==0)
                    {
                        liste = db.vw_urunler.Where(u => u.statusID == 3).OrderBy(u => u.ProductName).Take(sayfadakiurunsayisi).ToList();
                    }
                    else
                    {
                        liste = db.vw_urunler.Where(u => u.statusID == 3).OrderBy(u => u.ProductName).Skip(sayfano * sayfadakiurunsayisi).Take(sayfadakiurunsayisi).ToList();
                    }
                }
                if (urunler=="indirim")
                {
                    if (sayfano==0)
                    {
                        liste = db.vw_urunler.Where(u => u.Discount > 0).OrderByDescending(u => u.Discount).Take(sayfadakiurunsayisi).ToList();
                    }
                    else
                    {
                        liste = db.vw_urunler.Where(u => u.Discount > 0).OrderByDescending(u => u.Discount).Skip(sayfano * sayfadakiurunsayisi).Take(sayfadakiurunsayisi).ToList();
                    }
                }
                if (urunler=="onecikanlar")
                {
                    if (sayfano ==0)
                    {
                        liste = db.vw_urunler.OrderByDescending(u => u.OneCikanlar).Take(sayfadakiurunsayisi).ToList();
                    }
                    else
                    {
                        liste = db.vw_urunler.OrderByDescending(u => u.OneCikanlar).Skip(sayfano * sayfadakiurunsayisi).Take(sayfadakiurunsayisi).ToList();
                    }
                }
            }
            return liste;

        }
        public vw_urunler urungetir()
        {
            vw_urunler urun = db.vw_urunler.FirstOrDefault(s => s.statusID == 1);
            return urun;
        }
        public static void onecikanlarkolonuarttir(int id)
        {
            using(iakademi43gunceldbEntities db = new iakademi43gunceldbEntities())
            {
                tbl_Products prd = db.tbl_Products.FirstOrDefault(p => p.ProductID == id);
                prd.OneCikanlar += 1;
                db.SaveChanges();
            }
        }

    }
}