﻿using Projet_tchat.Models;
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
            Session["ID_send"] = id;
            List<MessageDTO> liste = bdd.message((int)Session["ID"], id);

            return View(liste);
        }

        [HttpPost]
      
        public void createmessage(Private_message p)
        {
            int i = (int)Session["ID"];
            int id = (int)Session["ID_send"];
           

            Private_message pm = new Private_message { id_sender = i, id_recepient = id, date_message = DateTime.Now, content = p.content };
            db.Private_message.Add(pm);
            db.SaveChanges();


        }

        public ContactController()
        {
            bdd = new Repository();
        }

    }
}