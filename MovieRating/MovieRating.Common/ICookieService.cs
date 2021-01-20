using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace MovieRating.Common
{
    public class CachedCookie
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public CookieOptions Options { get; set; }

        public bool IsDeleted { get; set; }
    }

    public interface ICookieService
    {
        void Delete(string cookieName);

        T Get<T>(string cookieName, bool isBase64 = false) where T : class;

        T GetOrSet<T>(string cookieName, Func<T> setFunc, DateTimeOffset? expiry = null, bool isBase64 = false) where T : class;

        void Set<T>(string cookieName, T data, DateTimeOffset? expiry = null, bool base64Encode = false) where T : class;

        void WriteToResponse(HttpContext context);
    }

	public class CookieService : ICookieService
	{
		private readonly HttpContext _HttpContext;
		private Dictionary<string, CachedCookie> PendingCookies = null;

		public CookieService(IHttpContextAccessor objHttpContextAccessor)
		{
			_HttpContext = objHttpContextAccessor.HttpContext;
			PendingCookies = new Dictionary<string, CachedCookie>();
		}

		protected CachedCookie Add(string cookieName)
		{
			var cookie = new CachedCookie
			{
				Name = cookieName
			};
			PendingCookies.Add(cookieName, cookie);

			return cookie;
		}

		void ICookieService.Delete(string cookieName)
		{
			Delete(cookieName);
		}

		protected CachedCookie Delete(string cookieName)
		{
			if (PendingCookies.TryGetValue(cookieName, out CachedCookie cookie))
				cookie.IsDeleted = true;
			else
			{
				cookie = new CachedCookie
				{
					Name = cookieName,
					IsDeleted = true
				};
				PendingCookies.Add(cookieName, cookie);
			}

			return cookie;
		}

		public T Get<T>(string cookieName, bool isBase64 = false)
			where T : class
		{
			return ExceptionHandler.SwallowOnException(() =>
			{
				// check local cache first...
				if (PendingCookies.TryGetValue(cookieName, out CachedCookie cookie))
				{
					// don't retrieve a "deleted" cookie
					if (cookie.IsDeleted)
						return default(T);

					return isBase64 ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cookie.Value.FromBase64String())
						: Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cookie.Value);
				}

				if (_HttpContext.Request.Cookies.TryGetValue(cookieName, out string cookieValue))
					return isBase64 ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cookieValue.FromBase64String())
						: Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cookieValue);

				return default(T);
			});
		}

		public T GetOrSet<T>(string cookieName, Func<T> setFunc, DateTimeOffset? expiry = null, bool isBase64 = false)
			where T : class
		{
			T cookie = Get<T>(cookieName, isBase64);

			if (cookie != null)
				return cookie;

			T data = setFunc();
			Set(cookieName, data, expiry, isBase64);

			return data;
		}

		public void Set<T>(string cookieName, T data, DateTimeOffset? expiry = null, bool base64Encode = false)
			where T : class
		{
			// info about cookieoptions
			CookieOptions options = new CookieOptions()
			{
				Secure = _HttpContext.Request.IsHttps,
				HttpOnly = true
			};
			if (expiry.HasValue)
				options.Expires = expiry.Value;

			if (!PendingCookies.TryGetValue(cookieName, out CachedCookie cookie))
				cookie = Add(cookieName);

			// always set options and value; // TODO: we may decide to handle this different later on...
			cookie.Options = options;
			cookie.Value = base64Encode
						? Newtonsoft.Json.JsonConvert.SerializeObject(data).ToBase64String()
						: Newtonsoft.Json.JsonConvert.SerializeObject(data);
		}

		public void WriteToResponse(HttpContext objHttpContext)
		{
			foreach (var cookie in PendingCookies.Values)
			{
				if (cookie.IsDeleted)
					objHttpContext.Response.Cookies.Delete(cookie.Name);
				else
					objHttpContext.Response.Cookies.Append(cookie.Name, cookie.Value, cookie.Options);
			}
		}
	}

	public static class ExceptionHandler
	{
		public static T SwallowOnException<T>(Func<T> func)
		{
			try
			{
				return func();
			}
			catch
			{
				return default(T);
			}
		}
	}
}
