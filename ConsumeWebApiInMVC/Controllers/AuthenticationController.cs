using ConsumeWebApiInMVC.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebApiInMVC.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }


        // GET: Authentication
     
        [HttpGet]
        public ActionResult Login()
        {
           
                return View(new Login());
            
            
        }
        [HttpPost]
        public ActionResult Login(Login login ,string returnurl="")
        {
            if (ModelState.IsValid)
            {
                if (login.UserName == "jo" && login.Password == "jo1234")
                {
                    IOwinContext context = Request.GetOwinContext();
                    IAuthenticationManager manager = context.Authentication;
                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, login.UserName));
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                    ClaimsIdentity identities = new ClaimsIdentity(claims, "ApplicationCookie");
                    manager.SignIn(identities: identities);

                    return RedirectToAction("GetProducts", "Products");
                }
                else
                {
                    return View("Error");
                }
                
            }
            return View(login);
        }
        public ActionResult Logout()
        { return RedirectToAction("GetProducts", "Products");
            IOwinContext context = Request.GetOwinContext();
            IAuthenticationManager manager = context.Authentication;
            manager.SignOut("ApplicationCookie");
            return Redirect("/");
        }
    }
}
