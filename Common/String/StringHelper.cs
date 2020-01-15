﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common.String
{

    /// <summary>
    /// 针对string字符串常用操作方法
    /// </summary>
    public static class StringHelper
    {


        /// <summary>
        /// 生成一个订单号
        /// </summary>
        /// <returns></returns>
        public static string GetOrderNo(string sign)
        {
            string orderno = "";

            Random ran = new Random();
            int RandKey = ran.Next(10000, 99999);


            orderno = sign + DateTime.Now.ToString("yyyyMMddHHmmssfff") + RandKey;

            return orderno;
        }




        /// <summary>
        /// 从传入的HTML代码中提取文本内容
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHtml(string Htmlstring)
        {

            //删除脚本

            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",

            RegexOptions.IgnoreCase);

            //删除HTML

            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",

            RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",

            RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");

            Htmlstring.Replace(">", "");

            Htmlstring.Replace("\r\n", "");

            Htmlstring = WebUtility.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;

        }


        /// <summary>
        /// 过滤删除掉字符串中的 Emoji 表情
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NoEmoji(string value)
        {
            foreach (var a in value)
            {
                byte[] bts = Encoding.UTF32.GetBytes(a.ToString());

                if (bts[0].ToString() == "253" && bts[1].ToString() == "255")
                {
                    value = value.Replace(a.ToString(), "");
                }

            }

            return value;
        }



        /// <summary>
        /// 对文本进行指定长度截取并添加省略号
        /// </summary>
        /// <param name="NeiRong"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringText(string NeiRong, int length)
        {
            //先对字符串做一次HTML解码
            NeiRong = HttpUtility.HtmlDecode(NeiRong);

            if (NeiRong.Length > length)
            {
                NeiRong = NeiRong.Substring(0, length);

                NeiRong = NeiRong + "...";

                return NoHtml(NeiRong);
            }
            else
            {
                return NoHtml(NeiRong);
            }
        }



        /// <summary>
        /// 对字符串进行脱敏处理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TextStars(string text)
        {
            if (text.Length >= 3)
            {
                int group = text.Length / 3;

                string stars = text.Substring(group, group);

                string pstars = "";

                for (int i = 0; i < group; i++)
                {
                    pstars = pstars + "*";
                }

                text = text.Replace(stars, pstars);
            }
            else
            {

                string stars = text.Substring(1, 1);

                string pstars = "";

                for (int i = 0; i < 1; i++)
                {
                    pstars = pstars + "*";
                }

                text = text.Replace(stars, pstars);
            }

            return text;
        }
    }
}
