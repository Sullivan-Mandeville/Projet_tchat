using Projet_tchat.Models;
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


    public class HomeController : Controller
    {

        private IRepository db;
        private TchatContext bdd = new TchatContext();


        //AFFICHAGE DE TOUS LES POSTS
        public ActionResult Index()
        {

            List<PostDTO> Lesposts = db.AllPost();
            List<int> Liste_post_ID = (from r in Lesposts select r.PostID).ToList();
            List<CommentDTO> LesCommentaires = db.ListeCommentaire(Liste_post_ID);
            List<PostVM> All_Post_Comment = new List<PostVM>();

            foreach (var item in Lesposts)
            {
                PostVM temp = new PostVM();
                temp.PostID = item.PostID;
                temp.nom = item.nom;
                temp.prenom = item.prenom;
                temp.content = item.content;

                temp.date_create = item.date_create;
                temp.Comments = LesCommentaires.Where(c => c.PostID == temp.PostID).ToList();
                All_Post_Comment.Add(temp);
            }

            if (Session["Nom"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {
                return View(All_Post_Comment);
            }


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public HomeController()
        {
            db = new Repository();
        }
    }
}