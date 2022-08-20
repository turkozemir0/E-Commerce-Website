using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websitesiprojesi60820222.Models
{
    public class cls_Categories
    {
        public static bool kategorikontrol(string kategoriadi)
        {
            using(iakademi43gunceldbEntities db = new iakademi43gunceldbEntities())
            {
                bool adi = db.tbl_Categories.Any(s => s.CategoryName == kategoriadi);
                return adi;
            }
        }
    }
}