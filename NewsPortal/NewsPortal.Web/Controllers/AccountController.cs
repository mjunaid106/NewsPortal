using System.Web.Mvc;
using NewsPortal.Data.Enums;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;
using NewsPortal.Web.Models;

namespace NewsPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;

        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        //
        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
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
                if (result.LoggedInUser.Role == Role.Publisher)
                {
                    return RedirectToAction("Manage", "Article");
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        //
        // /Account/LogOff
        public ActionResult LogOff()
        {
            Session["LoggedInUser"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}