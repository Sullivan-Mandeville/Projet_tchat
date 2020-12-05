using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.Models;
using Tchat.Infrastructure.DAL;

namespace Projet_tchat.Controllers
{
    public class CategoriesController : Controller
    {
        private TchatContext db = new TchatContext();

        // GET: Categories
        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if((int)Session["ID"]==5)
                {
                    return View(db.Category.ToList());
                }
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {  if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if ((int)Session["ID"] == 5)
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Categories/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryID,category_title")] Category category)
        {
          
                    if (ModelState.IsValid)
                    {
                        db.Category.Add(category);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(category);
      
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if((int)Session["ID"]==5)
                {
                        if (id == null)
                             {
                                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                              }
                               Category category = db.Category.Find(id);
                           if (category == null)
                           {
                               return HttpNotFound();
                            }
                            return View(category);
                }
                return RedirectToAction("Index", "Home");

            }
        }

        // POST: Categories/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryID,category_title")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if ((int)Session["ID"] == 5)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Category category = db.Category.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
                }
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
