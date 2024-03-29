﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ShopTrongGo.Models
{
    public class Func
    {
        //Hàm chuyển tiếng Việt có dấu sang không có dấu
        public string ConvertToUnSign3(string s)
        {
            s = s.Replace(" ", "-");
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public string LinkImage(string oldLink)
        {
            string[] link = oldLink.Split('/');
            if (link.Count() == 4)
            {
                return link[4];
            }
            if (link.Count() > 4)
            {
                return link[4] + "/" + link[5];
            }
                return oldLink;
        }
        public string GetMd5(string chuoi)
        {
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);                         
            var myMd5 = new MD5CryptoServiceProvider();
            mang = myMd5.ComputeHash(mang);
            return mang.Aggregate("", (current, b) => current + b.ToString("X2"));
        }
    }
}
