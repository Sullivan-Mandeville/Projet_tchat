﻿using Projet_tchat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tchat.Core.DTO;
using Tchat.Core.Models;
using Tchat.Infrastructure.dal;
using Tchat.Infrastructure.DAL;

namespace Projet_tchat.Controllers
{
    public class PostController : Controller
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

        //VOIR MES POSTS
        public ActionResult MesPosts()
        {

            if (Session["Nom"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {


                List<PostDTO> Lesposts = db.postByUserID((int)Session["ID"]);
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
                System.Diagnostics.Debug.WriteLine("ID USER" + LesCommentaires);
                return View(All_Post_Comment);
            }




        }

        //MODIFICATION
        public ActionResult Edit(int id)
        {
            MONPOSTIDDTO unpost = db.ididepost(id);

            if (unpost.userID == (int)Session["ID"])
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Post post = bdd.Post.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                ViewBag.categoryID = new SelectList(bdd.Category, "categoryID", "category_title", post.categoryID);
                return View(post);


            }
            else
            {
                return View("Index");
            }




        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "postID,userID,categoryID,content,date_create,modification_date,nb_like")] Post post)
        {
            if (ModelState.IsValid)
            {
                bdd.Entry(post).State = EntityState.Modified;
                bdd.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(bdd.Category, "categoryID", "category_title", post.categoryID);
            return View(post);



        }

        // DELETE
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = bdd.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = bdd.Post.Find(id);
            bdd.Post.Remove(post);
            bdd.SaveChanges();
            return RedirectToAction("Index");
        }

        //CREATION
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(bdd.Category, "categoryID", "category_title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "postID,userID,categoryID,content,date_create,modification_date,status,nb_like")] Post post)
        {
            if (ModelState.IsValid)
            {
                bdd.Post.Add(post);
                bdd.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(bdd.Category, "categoryID", "category_title", post.categoryID);
            return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public void createpost(Comment p)
        {

            int i = (int)Session["ID"];
            // System.Diagnostics.Debug.WriteLine("ID USER" +i);
            int id_post = (int)p.postID;
            //  System.Diagnostics.Debug.WriteLine("ID POST"+id_post);

            Comment c = new Comment { postID = id_post, userID = i, content = p.content };
            bdd.Comment.Add(c);
            bdd.SaveChanges();


        }

        public JsonResult GetPostContent()
        {
            List<PostDTO> Lesposts = db.AllPost();
            return Json(Lesposts);
        }

        public JsonResult GetPostByIDUser()
        {
            List<PostDTO> Lesposts = db.postByUserID((int)Session["ID"]);
            return Json(Lesposts);
        }





        public PostController()
        {
            db = new Repository();
        }



    }
}