﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApi.Libraries.Http
{
    public static class HttpContext
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static IWebHostEnvironment HostingEnvironment { get; set; }


        public static void Add(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }


        public static void Initialize(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceProvider = app.ApplicationServices;
            HostingEnvironment = env;
        }


        public static Microsoft.AspNetCore.Http.HttpContext Current()
        {
            object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
            Microsoft.AspNetCore.Http.HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
            return context;
        }


        /// <summary>
        /// 获取Url信息
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return $"{HttpContext.Current().Request.Scheme}://{HttpContext.Current().Request.Host.Host}{HttpContext.Current().Request.Path}{HttpContext.Current().Request.QueryString}";
        }


        /// <summary>
        /// 获取基础Url信息
        /// </summary>
        /// <returns></returns>
        public static string GetBaseUrl()
        {
            return $"{HttpContext.Current().Request.Scheme}://{HttpContext.Current().Request.Host.Host}:{HttpContext.Current().Request.Host.Port}";
        }


        /// <summary>
        /// RequestBody中的内容
        /// </summary>
        public static string RequestBody;



        /// <summary>
        /// 获取 http 请求中的全部参数
        /// </summary>
        public static List<dtoKeyValue> GetParameter()
        {
            var context = Current();

            var parameters = new List<dtoKeyValue>();

            if (context.Request.Method == "POST")
            {
                string body = WebApi.Libraries.Http.HttpContext.RequestBody;

                if (!string.IsNullOrEmpty(body))
                {
                    parameters.Add(new dtoKeyValue { Key = "body", Value = body });
                }
                else if (context.Request.HasFormContentType)
                {
                    var fromlist = context.Request.Form.OrderBy(t => t.Key).ToList();

                    foreach (var fm in fromlist)
                    {
                        parameters.Add(new dtoKeyValue { Key = fm.Key, Value = fm.Value.ToString() });
                    }
                }
            }
            else if (context.Request.Method == "GET")
            {
                var queryList = context.Request.Query.ToList();

                foreach (var query in queryList)
                {
                    parameters.Add(new dtoKeyValue { Key = query.Key, Value = query.Value });
                }
            }

            return parameters;
        }
    }
}
