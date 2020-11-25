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
            if (logg == null)
            {
                return HttpNotFound();
            } 
            
            String premierCaractere = logg.name.Substring(0,1);
            String premierCar = logg.firstname.Substring(0, 1);
         
           Session["CarNom"] = premierCaractere;
           Session["CarPrenom"] = premierCar;
           Session["Nom"] = logg.name;
           Session["Prenom"] = logg.firstname;
           Session["ID"] = logg.id_user;

           return RedirectToAction("Index","Home");
           

        }

        public LoginController()
        {
            db = new Repository();
        }

    }
}