using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.DTO;
using Tchat.Infrastructure.dal;
using Tchat.Infrastructure.DAL;

namespace Projet_tchat.Controllers
{
    public class LoginController : Controller
    {
        private IRepository db;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Connexion(String log_username, String log_password)
        {
           LoginDTO logg = db.Authentifier(log_username,log_password);
            if (logg != null)
            {
               return RedirectToAction("Index","Categories");
            }
            return HttpNotFound();
           
        }

        public LoginController()
        {
            db = new Repository();
        }

    }
}