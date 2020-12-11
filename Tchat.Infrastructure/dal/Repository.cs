using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.DTO;
using Tchat.Core.Models;
using Tchat.Infrastructure.DAL;

namespace Tchat.Infrastructure.dal
{
    public class Repository : IRepository

    {


        private TchatContext db = new TchatContext();

        public List<PostDTO> AllPost()
        {
            var post_liste = (
                from r in db.Post
                join u in db.User on r.userID equals u.userID
                select new PostDTO { content = r.content, nom = u.name, prenom = u.firstname, date_create = r.date_create,  PostID = r.postID });
            return post_liste.ToList();
        }

        public LoginDTO Authentifier(string email, string password)
        {
            var logg = (from r in db.User where r.email == email && r.password == password select new LoginDTO { firstname = r.firstname, name = r.name, id_user = r.userID }).FirstOrDefault();
            return logg;

        }

        public MONPOSTIDDTO ididepost(int postid)
        {
            var logg = (from r in db.Post where r.postID == postid select new MONPOSTIDDTO { userID = r.userID, postID = r.postID }).FirstOrDefault();
            return logg;
        }

        /*public PostDTO like(int id_post, int id_user)
        {
            var logg = (from p in db.Post where p.postID = id_post && p.userID =id_user )
        }*/



        public List<UserDTO> liste()
        {
            var req = (from r in db.User select new UserDTO { prenom = r.firstname, nom = r.name, UserID = r.userID, mail = r.email });
            return req.ToList();
        }

        public List<CommentDTO> ListeCommentaire(List<int> PostID)
        {
            var req = (from r in db.Comment
                       join u in db.User on r.userID equals u.userID
                       where PostID.Contains(r.postID)
                       select new CommentDTO { content = r.content, nom = u.name, prenom = u.firstname, PostID = r.postID });
            return req.ToList();
        }

        public List<PostDTO> postByUserID(int UserID)
        {
            var post_liste = (
                from r in db.Post join u in db.User on r.userID equals u.userID where u.userID == UserID
                select new PostDTO { content = r.content, nom = u.name, prenom = u.firstname, date_create = r.date_create, PostID = r.postID });
            return post_liste.ToList();
        }

        public List<MessageDTO> message(int id_sender, int id_recepient)
        {
            var liste_message = (
                from r in db.Private_message
                join u in db.User on r.id_recepient equals u.userID
                join x in db.User on r.id_sender equals x.userID
                where (r.id_recepient == id_sender || r.id_sender == id_sender) && (r.id_recepient == id_recepient || r.id_sender == id_recepient)
                select new MessageDTO { content = r.content, date_message = r.date_message, nom = x.name, prenom = x.firstname, id_sender = (int)r.id_sender, id_recepient = (int)r.id_recepient });

            return liste_message.ToList();
        }


    }
}
