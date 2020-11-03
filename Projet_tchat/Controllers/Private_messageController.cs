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
    public class Private_messageController : Controller
    {
        private TchatContext db = new TchatContext();

        // GET: Private_message
        public ActionResult Index()
        {
            var private_message = db.Private_message.Include(p => p.recepient).Include(p => p.room).Include(p => p.sender);
            return View(private_message.ToList());
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
            ViewBag.id_recepient = new SelectList(db.User, "userID", "name");
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room");
            ViewBag.id_sender = new SelectList(db.User, "userID", "name");
            return View();
        }

        // POST: Private_message/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_private_message,content,roomID,id_sender,id_recepient")] Private_message private_message)
        {
            if (ModelState.IsValid)
            {
                db.Private_message.Add(private_message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_recepient = new SelectList(db.User, "userID", "name", private_message.id_recepient);
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room", private_message.roomID);
            ViewBag.id_sender = new SelectList(db.User, "userID", "name", private_message.id_sender);
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
            ViewBag.id_recepient = new SelectList(db.User, "userID", "name", private_message.id_recepient);
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room", private_message.roomID);
            ViewBag.id_sender = new SelectList(db.User, "userID", "name", private_message.id_sender);
            return View(private_message);
        }

        // POST: Private_message/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_private_message,content,roomID,id_sender,id_recepient")] Private_message private_message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(private_message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_recepient = new SelectList(db.User, "userID", "name", private_message.id_recepient);
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room", private_message.roomID);
            ViewBag.id_sender = new SelectList(db.User, "userID", "name", private_message.id_sender);
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
