using Projet_tchat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using Tchat.Core.DTO;
using Tchat.Core.Models;
using Tchat.Infrastructure.dal;
using Tchat.Infrastructure.DAL;

namespace Projet_tchat.Controllers
{
    public class ContactController : Controller
    {
        private TchatContext db = new TchatContext();
        private IRepository bdd;
        // GET: Contact
        public ActionResult Index()
        {
            List<UserDTO> liste_contact = bdd.liste();
            return View(liste_contact);
        }

        public ActionResult MesMessages(int id)
        {
           // MessageModel mm = new MessageModel();
           // mm.messageVue = bdd.message((int)Session["ID"], id);
           // mm.messageEdit = bdd.messsageprivée((int)Session["id"],id,content);
            List<MessageDTO> liste = bdd.message((int)Session["ID"], id);
            return View(liste);
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Envoyer()
        {
            return View();
        }

        public ContactController()
        {
            bdd = new Repository();
        }

    }
}