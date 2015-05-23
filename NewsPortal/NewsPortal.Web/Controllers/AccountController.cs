using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewsPortal.Data.Context;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Repository;
using NewsPortal.Domain.Authentication;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;
using NewsPortal.Web.Models;

namespace NewsPortal.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;

        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AuthenticationResponse result = _authentication.IsUserAuthenticated(model.Username, model.Password);

            if (result.Success)
            {
                Session["LoggedInUser"] = result.LoggedInUser;
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            Session["LoggedInUser"] = null;
            return RedirectToAction("Index", "Home");
        }


        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}