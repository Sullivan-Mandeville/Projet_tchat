using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.DTO;
using Tchat.Infrastructure.dal;

namespace Projet_tchat.Controllers
{
    public class UtilisateursController : Controller
    {
        // GET: Utilisateurs
        private IRepository db;
        
       
        // GET: PostCtrler
        public ActionResult Index()
        { 
            List<UserDTO> liste_uti = db.liste();
            return View(liste_uti);
        }

        



        public UtilisateursController()
        {
            db = new Repository();
        }
    }
}