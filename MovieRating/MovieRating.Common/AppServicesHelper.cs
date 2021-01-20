using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;

namespace MovieRating.Common
{
    public static class AppServicesHelper
    {
        static IServiceProvider _ServiceProvider = null;        

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider ServiceProvider
        {
            get { return _ServiceProvider; }
            set
            {
                if (_ServiceProvider != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                _ServiceProvider = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        public static HttpContext CurrentHttpContext
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = ServiceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        public static string WebsiteURL
        {
            get
            {
                string url = string.Empty;                   

                if (CurrentHttpContext != null && CurrentHttpContext.Request != null)
                {
                    Uri objUriCurrentRequest = new Uri(CurrentHttpContext.Request.GetDisplayUrl());

                    string port = (objUriCurrentRequest.Port != 80 || objUriCurrentRequest.Port != 443) ? objUriCurrentRequest.Port.ToString() : string.Empty;

                    url = objUriCurrentRequest.Scheme + "://" + objUriCurrentRequest.Host + (!string.IsNullOrWhiteSpace(port) ? ":" + port : string.Empty) + "/";
                }

                return url;
            }
        }



      

        /// <summary>
        /// Get Host environment
        /// </summary>
        public static IWebHostEnvironment WebHostEnvironment
        {
            get
            {
                return ServiceProvider.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            }
        }

        /// <summary>
        /// Get Data Protector
        /// </summary>
        public static IDataProtector DataProtector
        {
            get
            {
                IDataProtector objDataProtector = ServiceProvider.GetDataProtector("MVCCore.Web");
                return objDataProtector;
            }
        }

        /// <summary>
        /// Get Memory Cache
        /// </summary>
        public static IMemoryCache MemoryCache
        {
            get
            {
                IMemoryCache objMemoryCache = ServiceProvider.GetService(typeof(IMemoryCache)) as IMemoryCache;
                return objMemoryCache;
            }
        }


        /// <summary>
        /// Get HttpContextAccessor
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor
        {
            get
            {
                IHttpContextAccessor objHttpContextAccessor = ServiceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return objHttpContextAccessor;
            }
        }

        /// <summary>
        /// Configuration settings from appsetting.json.
        /// </summary>
        public static ApplicationConfiguration ApplicationConfiguration
        {
            get
            {
                //This works to get file changes.
                var objOptionsMonitor = ServiceProvider.GetService(typeof(IOptionsMonitor<ApplicationConfiguration>)) as IOptionsMonitor<ApplicationConfiguration>;
                ApplicationConfiguration objApplicationConfiguration = objOptionsMonitor.CurrentValue;
                return objApplicationConfiguration;
            }
        }
    }
}

