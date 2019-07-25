using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ConsumeWebApiInMVC.Startup))]

namespace ConsumeWebApiInMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            CookieAuthenticationOptions options = new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Authentication/Login"),
             //   ExpireTimeSpan = TimeSpan.FromDays(-1),
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = ctx => {
                        if (!IsAjaxRequest(ctx.Request))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                }
                // DateTime.Now.AddDays(-1d);

            };
            app.UseCookieAuthentication(options);
        }

        private static bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query = request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }
    }
}