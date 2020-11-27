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
        {// Le 1 est à changer et il aut récupérer l'id de la personne à qui on parle ! (PRENDRE EXEMPLE SUR LE POST)
            List<MessageDTO> liste = bdd.message((int)Session["ID"], id);

            return View(liste);
        }

        public ContactController()
        {
            bdd = new Repository();
        }

    }
}