﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.BaiduAi
{
    public class ImageClassify
    {


        /// <summary>
        /// 图像主体检测
        /// </summary>
        /// <returns></returns>
        public static Newtonsoft.Json.Linq.JObject ObjectDetect(string path)
        {
            var image = File.ReadAllBytes(path);

            var result = Client.ImageClassify().ObjectDetect(image);

            Console.WriteLine(result);

            return result;
        }
    }
}
