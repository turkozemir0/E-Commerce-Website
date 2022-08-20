using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websitesiprojesi60820222.Models
{
    public class cls_Settings
    {
        public static bool ayarlarkaydet(tbl_Settings set)
        {
            using (iakademi43gunceldbEntities db = new iakademi43gunceldbEntities())
            {
                try
                {
                    db.tbl_Settings.Add(set);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    
                }
            }
        }
    }
}