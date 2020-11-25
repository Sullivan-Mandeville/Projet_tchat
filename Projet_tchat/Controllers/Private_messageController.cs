using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class Private_messageController : Controller
    {

        private TchatContext db = new TchatContext();
        private IRepository bdd;

        // GET: Private_message
        public ActionResult Index()
        {
            return View(db.Private_message.ToList());
        }

        // GET: Private_message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Private_message private_message = db.Private_message.Find(id);
            if (private_message == null)
            {
                return HttpNotFound();
            }
            return View(private_message);
        }

        // GET: Private_message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Private_message/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "private_messageID,content,date_message,id_sender,id_recepient")] Private_message private_message)
        {
            if (ModelState.IsValid)
            {
                db.Private_message.Add(private_message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(private_message);
        }

        // GET: Private_message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Private_message private_message = db.Private_message.Find(id);
            if (private_message == null)
            {
                return HttpNotFound();
            }
            return View(private_message);
        }

        // POST: Private_message/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "private_messageID,content,date_message,id_sender,id_recepient")] Private_message private_message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(private_message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(private_message);
        }

        // GET: Private_message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Private_message private_message = db.Private_message.Find(id);
            if (private_message == null)
            {
                return HttpNotFound();
            }
            return View(private_message);
        }

        // POST: Private_message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Private_message private_message = db.Private_message.Find(id);
            db.Private_message.Remove(private_message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MesMessages()
        {
            List<MessageDTO> liste = bdd.message((int)Session["ID"], 1);

            return View(liste);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public Private_messageController()
        {
            bdd = new Repository();
        }
    }
}
