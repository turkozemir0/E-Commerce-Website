using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websitesiprojesi60820222.Models;
using websitesiprojesi60820222.MVVM;
using System.Drawing;
using System.Drawing.Imaging;
using PagedList;

namespace websitesiprojesi60820222.Controllers
{
    public class HomeController : BaseController
    {
        iakademi43gunceldbEntities db = new iakademi43gunceldbEntities();
        int sayfadakiurunsayisi;
        int anasayfadakiurunsayisi;
        public HomeController()
        {
            sayfadakiurunsayisi = ViewBag.sayfadakiurunsayisi;
            anasayfadakiurunsayisi = ViewBag.anasayfadakiurunsayisi;
        }
        anasayfamodel ans = new anasayfamodel();
        cls_Users user = new cls_Users();
        cls_Products prd = new cls_Products();
        // GET: Home
        public ActionResult Index()
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;

            ans.yeniUrunler = prd.urunlergetir("yeni", "anasayfa", 0);
            ans.yildizliUrunler = prd.urunlergetir("yildiz", "anasayfa", 0);
            ans.indirimliUrunler = prd.urunlergetir("indirim", "anasayfa", 0);
            ans.onecikanUrunler = prd.urunlergetir("onecikanlar", "anasayfa", 0);
            ans.gunun_urunu = prd.urungetir();
            ans.coksatanUrunler = prd.urunlergetir("coksatanlar", "anasayfa", 0);
            ans.ozelUrunler = prd.urunlergetir("ozel", "anasayfa", 0);
            ans.sliderUrunler = prd.urunlergetir("slider", "anasayfa", 0);
            return View(ans);
        }

        //Menu
        public ActionResult detayliarama()
        {
            return View();
        }
        public ActionResult giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult giris(tbl_Users users)
        {
            tbl_Users usr = user.uyekontrol(users);
            if (usr==null)
            {
                Session["Mesaj"] = "Bilgileriniz hatalı yeniden deneyin";
                return View();
            }
            else
            {
                if (usr.IsAdmin==true)
                {
                    return RedirectToAction("AnaSayfa", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult cikis()
        {
            return View();
        }

        public ActionResult Uyeol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uyeol(tbl_Users user)
        {
            cls_Users u = new cls_Users();
            u.captcha = Session["randstr"].ToString();
            string txtcaptcha = Request.Form["txtcaptcha"];
            if (txtcaptcha == u.captcha)
            {
                user.IsAdmin = false;
                user.Active = true;
                bool sonuc = cls_Users.uyeekle(user);
                if (sonuc == true)
                {
                    Session["Mesaj"] = "Üyelik kaydınız başarılı.İyi Alışverişler.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Mesaj"] = "Üyelik kaydınız yapılamadı hata!";
                    return View();
                }

            }
            else
            {
                Session["Mesaj"] = "Güvenlik rakamını yanlış girdiniz";
                return View();
            }
        }
        public ActionResult captcha()
        {
            Bitmap bmp = new Bitmap(60, 20);
            Graphics grp = Graphics.FromImage(bmp);
            grp.Clear(Color.Blue);
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font fnt = new Font("Ariel", 8, FontStyle.Bold);
            string randstr = "";
            int[] myintArray = new int[5];
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                myintArray[i] = r.Next(0, 9);
                randstr += myintArray[i].ToString();
            }

            Session["randstr"] = randstr;
            cls_Users u = new cls_Users();
            u.captcha = randstr;
            grp.DrawString(randstr, fnt, Brushes.White, 3, 3);
            Response.ContentType = "image/GIF";
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
            fnt.Dispose();
            grp.Dispose();
            bmp.Dispose();

            return View();
        }
        public ActionResult hakkimizda()
        {
            return View();
        }
        public ActionResult iletisim()
        {
            return View();
        }

        //headr
        public ActionResult enyeniler()
        {
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            ans.yeniUrunler = prd.urunlergetir("yeni", "altsayfa", 0);
            return View(ans);
        }
        public ActionResult _partial_enyeniler(string sonrakisayfa)
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            int sayfano = Convert.ToInt32(sonrakisayfa);
            ans.yeniUrunler = prd.urunlergetir("yeni", "altsayfa", sayfano);
            return PartialView(ans);
        }
        public ActionResult ozelurunler()
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            ans.ozelUrunler = prd.urunlergetir("ozel", "altsayfa", 0);
            return View(ans);
        }
        public ActionResult _partial_ozelurunler(string sonrakisayfa)
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            int sayfano = Convert.ToInt32(sonrakisayfa);
            ans.ozelUrunler = prd.urunlergetir("ozel", "altsayfa", sayfano);
            return PartialView(ans);
        }
        public ActionResult indirimliurunler()
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            ans.indirimliUrunler = prd.urunlergetir("indirimli", "altsayfa", 0);
            return View(ans);
        }
        public ActionResult _partial_indirimliurunler(string sonrakisayfa)
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            int sayfano = Convert.ToInt32(sonrakisayfa);
            ans.indirimliUrunler = prd.urunlergetir("indirimli", "altsayfa", sayfano);
            return PartialView(ans);
        }
        public ActionResult onecikanlar()
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            ans.onecikanUrunler = prd.urunlergetir("onecikanlar", "altsayfa", 0);
            return View(ans);
        }

        public ActionResult _partial_onecikanlar(string sonrakisayfa)
        {
            cls_Products.sayfadakiurunsayisi = sayfadakiurunsayisi;
            cls_Products.anasayfadakiurunsayisi = anasayfadakiurunsayisi;
            int sayfano = Convert.ToInt32(sonrakisayfa);
            ans.onecikanUrunler = prd.urunlergetir("onecikanlar", "altsayfa", sayfano);
            return PartialView(ans);
        }
        public ActionResult coksatanlar(int? page)
        {
            var pagenumber = page ?? 1;
            var ulist = db.vw_urunler.OrderByDescending(c => c.CokSatanlar).ToList();
            var sayfalidata = ulist.ToPagedList(pagenumber, sayfadakiurunsayisi);
            ViewBag.coksatanlar = sayfalidata;
            return View();
        }

        public ActionResult kategoriler(int? page,int id)
        {
            var pagenumber = page ?? 1;
            var ulist = db.vw_urunler.Where(c => c.CategoryID == id).ToList();
            var sayfalidata = ulist.ToPagedList(pagenumber, sayfadakiurunsayisi);
            ViewBag.kategoriler = sayfalidata;
            ViewBag.baslik = db.tbl_Categories.FirstOrDefault(c => c.CategoryID == id).CategoryName;
            return View();
        }
        public ActionResult markalar(int? page,int id)
        {
            var pagenumber = page ?? 1;
            var ulist = db.vw_urunler.Where(s => s.SupplierID == id).ToList();
            var sayfalidata = ulist.ToPagedList(pagenumber, sayfadakiurunsayisi);
            ViewBag.markalar = sayfalidata;
            ViewBag.baslik = db.tbl_Suppliers.FirstOrDefault(s => s.SupplierID == id).BrandName;
            return View();
        }
        public ActionResult siparislerim()
        {
            return View();
        }
        public ActionResult detaylar(int id)
        {
            cls_Products.onecikanlarkolonuarttir(id);
            return View();
        }
        public ActionResult sepet(int id)
        {
            cls_Products.onecikanlarkolonuarttir(id);
            HttpCookie cSetCookie;
            string sepet = "";
            cls_Orders order = new cls_Orders();
            order.ProductID = id;
            order.Adet = 1;

            cSetCookie = Request.Cookies.Get("sepetim");
            if (cSetCookie == null)
            {
                cSetCookie = new HttpCookie("sepetim");
                order.Sepet = "";
            }
            else
            {
                order.Sepet = cSetCookie.Value;
            }
            if (order.SepeteEkle(id) == true)
            {
                cSetCookie.Values.Add(id.ToString(), "1");
                cSetCookie.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
                Response.Cookies.Add(cSetCookie);
                Session["Mesaj"] = "Ürün sepetinize eklendi";

            }
            else
            {
                Session["Mesaj"] = "Ürün sepetinizde zaten var";
            }
            string url = Request.UrlReferrer.ToString();
            if (url.Length>24)
            {
                string sil = url.Substring(0, 29);
                url = url.Replace(sil, "");
                return RedirectToAction(url);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}