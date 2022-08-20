using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websitesiprojesi60820222.Models
{
    public class cls_Orders
    {
        public int ProductID { get; set; }
        public int Adet { get; set; }
        public string Sepet { get; set; }
        public decimal Fiyat { get; set; }
        public string Urunad { get; set; }
        public int Kdv { get; set; }
        public int Discount { get; set; }

        iakademi43gunceldbEntities db = new iakademi43gunceldbEntities();
        public bool SepeteEkle(int spid)
        {
            bool varmi = true;
            string[] sepetdizi = Sepet.Split('&');
            for (int i = 0; i < sepetdizi.Length; i++)
            {
                string[] sepetdizi_productid_adet = sepetdizi[i].Split('=');
                if (sepetdizi_productid_adet[0]==spid.ToString())
                {
                    varmi = false;
                }
            }
            return varmi;
        }
        public List<cls_Orders> sepetiyazdir()
        {
            List<cls_Orders> list = new List<cls_Orders>();
            string[] sepetdizi = Sepet.Split('&');
            for (int i = 0; i < sepetdizi.Length; i++)
            {
                string[] sepetdizi_productid_adet = sepetdizi[i].Split('=');
                int sepetid = int.Parse(sepetdizi_productid_adet[0]);
                if (sepetdizi_productid_adet[0] != "")
                {
                    for (int a = 0; a < sepetdizi.Length; a++)
                    {
                        tbl_Products prd = db.tbl_Products.FirstOrDefault(p => p.ProductID == sepetid);
                        cls_Orders s = new cls_Orders();
                        s.Urunad = prd.ProductName;
                        s.ProductID = sepetid;
                        s.Fiyat = Convert.ToDecimal(prd.Price);
                        s.Kdv = Convert.ToInt32(prd.Kdv);
                        s.Adet = Convert.ToInt32(sepetdizi_productid_adet[1]);
                        list.Add(s);
                    }
                }
            }
            return list;
        }

    }
}