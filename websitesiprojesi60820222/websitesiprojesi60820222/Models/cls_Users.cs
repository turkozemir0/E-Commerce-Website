using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace websitesiprojesi60820222.Models
{
    public class cls_Users
    {
        public string captcha { get; set; }

        iakademi43gunceldbEntities db = new iakademi43gunceldbEntities();

        public tbl_Users uyekontrol(tbl_Users user)
        {
            
            
                tbl_Users us = db.tbl_Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                return us;
            
        }
        public static bool uyeekle(tbl_Users user)
        {
            using (iakademi43gunceldbEntities db = new iakademi43gunceldbEntities())
            {
                try
                {
                    db.tbl_Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public tbl_Users uyegetir(int UserID)
        {
            using(iakademi43gunceldbEntities db = new iakademi43gunceldbEntities())
            {
                tbl_Users us = db.tbl_Users.FirstOrDefault(u => u.UserID == UserID);
                return us;
            }
        }

        
    }
}