using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using UyelikSistemi.Models;
using UyelikSistemi.Utility;
using UyelikSistemi.ViewModels;

namespace UyelikSistemi.Controllers
{
    public class HesapController : Controller
    {
        KisiselGelisimContext db = new KisiselGelisimContext();
        // GET: Hesap


        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KayitOl(KayitOlViewModel vm)
        {
            //Kullanıcı Adı mevcut mu?
            if (db.Kullanicilar.Any(x => x.KullaniciAd == vm.Email))
            {
                ModelState.AddModelError("Email", "E-mail adresi kullanımda.");
            }

            if (ModelState.IsValid)
            {
                Kullanici kullanici = new Kullanici
                {
                    KullaniciAd = vm.Email,
                    ParolaHash = Security.HashPassword(vm.Parola)
                };
                db.Kullanicilar.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Giris", "Hesap", new { kayit = "basarili" });
            }
            return View();
        }
        public ActionResult Giris(string kayit)
        {
            ViewBag.kayit = kayit;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(GirisViewModel vm, string donusUrl)
        {
            if (ModelState.IsValid)
            {
                //kullanıcı adı ve parolayı kontrol et
                var kullanici = db.Kullanicilar.SingleOrDefault(x => x.KullaniciAd == vm.Email);

                if (kullanici == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı ya da parola yanlış!");
                }
                if (ModelState.IsValid)
                {
                    if (kullanici.ParolaHash == Security.HashPassword(vm.Parola))
                    {
                        // https://stackoverflow.com/questions/31584506/how-to-implement-custom-authentication-in-asp-net-mvc-5
                        // todo: cookie authentication yap

                        var ident = new ClaimsIdentity(
                          new[] { 
                              // adding following 2 claim just for supporting default antiforgery provider
                              new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()),
                              new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

                              new Claim(ClaimTypes.Name, kullanici.KullaniciAd),

                              // optionally you could add roles if any
                              new Claim(ClaimTypes.Role, "Guest"),


                          },
                          DefaultAuthenticationTypes.ApplicationCookie);

                        HttpContext.GetOwinContext().Authentication.SignIn(
                           new AuthenticationProperties { IsPersistent = true }, ident);

                        return RedirectToAction("Index", "Home");

                    }

                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı ya da parola yanlış!");
                    }
                }
            }

            return View();
        }

        public ActionResult Cikis()
        {
            // todo: çıkış yap
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}