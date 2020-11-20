using Projet_tchat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.DTO;
using Tchat.Infrastructure.dal;

namespace Projet_tchat.Controllers
{
    public class PostController : Controller
    {
        private IRepository db;
        // GET: PostCtrler
    

        public ActionResult Index()
        {

          List<PostDTO> Lesposts = db.AllPost();
          List<int> Liste_post_ID=  (from r in Lesposts select r.PostID).ToList() ;
          List<CommentDTO> LesCommentaires = db.ListeCommentaire(Liste_post_ID);
          List<PostVM> All_Post_Comment = new List<PostVM>();
            
            foreach (var item in Lesposts)
            {
                PostVM temp = new PostVM();
                temp.PostID = item.PostID;
                temp.nom = item.nom;
                temp.prenom = item.prenom;
                temp.content = item.content;
                temp.nb_like = item.nb_like;
                temp.Comments = LesCommentaires.Where(c => c.PostID == temp.PostID).ToList();
                All_Post_Comment.Add(temp);
            }

            return View(All_Post_Comment);
        }

        public ActionResult MesPosts()
        {

              List<PostDTO> Lesposts = db.postByUserID((int)Session["ID"]);

            return View(Lesposts);
        }

        public PostController()
        {
            db = new Repository();
        }
    }
}