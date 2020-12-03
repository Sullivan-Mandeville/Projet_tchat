using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.DTO;
using Tchat.Core.Models;
using Tchat.Infrastructure.dal;
using Tchat.Infrastructure.DAL;

namespace Projet_tchat.Controllers
{
    public class UtilisateursController : Controller
    {
        // GET: Utilisateurs
        private IRepository db;
        private TchatContext bdd = new TchatContext();



        // GET: PostCtrler
     

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,name,firstname,email,password,date_create,modification_date")] User user)
        {
            if (ModelState.IsValid)
            {
                bdd.User.Add(user);
                bdd.SaveChanges();
                return RedirectToAction("Index","Login");
            }

            return View(user);
        }

        public ActionResult Edit()
        {
            if (Session["ID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = bdd.User.Find(Session["ID"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,name,firstname,email,password,date_create,modification_date")] User user)
        {
            if (ModelState.IsValid)
            {
                bdd.Entry(user).State = EntityState.Modified;
                bdd.SaveChanges();

                String premierCaractere = user.name.Substring(0, 1);
                String premierCar = user.firstname.Substring(0, 1);
                Session["CarNom"] = premierCaractere;
                Session["CarPrenom"] = premierCar;
                Session["Nom"] = user.name;
                Session["Prenom"] = user.firstname;

                return RedirectToAction("Index","Home");
            }
            return View(user);
        }


        public ActionResult Delete()
        {
            if (Session["ID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = bdd.User.Find(Session["ID"]);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            User user = bdd.User.Find(Session["ID"]);
            bdd.User.Remove(user);
            bdd.SaveChanges();
            return RedirectToAction("Deco","Login");
        }







        public UtilisateursController()
        {
            db = new Repository();
        }
    }
}