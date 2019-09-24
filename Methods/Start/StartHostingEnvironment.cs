﻿using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Methods.Start
{
    public class StartHostingEnvironment
    {
        public static IWebHostEnvironment webHostEnvironment;

        public static void Add(IWebHostEnvironment in_webHostEnvironment)
        {
            webHostEnvironment = in_webHostEnvironment;
        }

    }
}
