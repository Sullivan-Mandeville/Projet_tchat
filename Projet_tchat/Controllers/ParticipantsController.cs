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
    public class ParticipantsController : Controller
    {
        private TchatContext db = new TchatContext();

        // GET: Participants
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.room).Include(p => p.user);
            return View(participants.ToList());
        }

        // GET: Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participants participants = db.Participants.Find(id);
            if (participants == null)
            {
                return HttpNotFound();
            }
            return View(participants);
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room");
            ViewBag.userID = new SelectList(db.User, "userID", "name");
            return View();
        }

        // POST: Participants/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "participantsID,userID,roomID")] Participants participants)
        {
            if (ModelState.IsValid)
            {
                db.Participants.Add(participants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room", participants.roomID);
            ViewBag.userID = new SelectList(db.User, "userID", "name", participants.userID);
            return View(participants);
        }

        // GET: Participants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participants participants = db.Participants.Find(id);
            if (participants == null)
            {
                return HttpNotFound();
            }
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room", participants.roomID);
            ViewBag.userID = new SelectList(db.User, "userID", "name", participants.userID);
            return View(participants);
        }

        // POST: Participants/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "participantsID,userID,roomID")] Participants participants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roomID = new SelectList(db.Room, "roomID", "name_room", participants.roomID);
            ViewBag.userID = new SelectList(db.User, "userID", "name", participants.userID);
            return View(participants);
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participants participants = db.Participants.Find(id);
            if (participants == null)
            {
                return HttpNotFound();
            }
            return View(participants);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participants participants = db.Participants.Find(id);
            db.Participants.Remove(participants);
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
