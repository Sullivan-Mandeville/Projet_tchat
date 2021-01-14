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
            List<ContactVM> Contact_message = new List<ContactVM>();

            foreach (var item in liste_contact)
            {
                ContactVM temp = new ContactVM();
                temp.userID = item.UserID;
                temp.nom = item.nom;
                temp.prenom = item.prenom;
                List<MessageDTO> dernier_message = bdd.message((int)Session["ID"], item.UserID);
             
                    MessageDTO temporaire = dernier_message.LastOrDefault();
                    temp.message = temporaire;
                    System.Diagnostics.Debug.WriteLine("Message : " + temp.message);
                

                Contact_message.Add(temp);
            }

            if (Session["Nom"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {
                return View(Contact_message);
            }

        }

        
        public ActionResult MesMessages(int id)
        {
            if (Session["Nom"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {
               Session["ID_send"] = id;
            List<MessageDTO> liste = bdd.message((int)Session["ID"], id);
                // RECUPERER LE NOM + PRENOM POUR L'AFFICHER DANS "MES MESSAGES"
                UserDTO us = bdd.utilisateurmessage(id);
                Session["nom_message"] = us.nom;
                Session["prenom_message"] = us.prenom;

            return View();
            }


            
        }

        public JsonResult MessagesByID(int id)
        {
            if (Session["Nom"] == null)
            {
                RedirectToAction("Index", "Login");
                return null;

            }
            else
            {
                Session["ID_send"] = id;
                List<MessageDTO> liste = bdd.message((int)Session["ID"], id);

                return Json(liste);
            }



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