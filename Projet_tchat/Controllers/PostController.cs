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
           
            List<PostDTO> Lesposts = db.post((int)Session["ID"]);

            return View(Lesposts);
          

        }

        public PostController()
        {
            db = new Repository();
        }
    }
}