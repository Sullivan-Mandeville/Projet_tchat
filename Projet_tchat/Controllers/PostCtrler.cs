using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.DTO;
using Tchat.Infrastructure.dal;

namespace Projet_tchat.Controllers
{
    public class PostCtrler : Controller
    {
        private IRepository db;
        // GET: PostCtrler
        public ActionResult Index()
        {
            return View();
        }

        public List<PostDTO>  mesPosts(int i )
        {
            i = (int)Session["ID"];
            List<PostDTO> Lesposts = db.post(i);

            return Lesposts;
           
        }

        public PostCtrler()
        {
            db = new Repository();
        }
    }
}