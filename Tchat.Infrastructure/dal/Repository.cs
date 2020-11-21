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
                select new PostDTO { content = r.content, nom = u.name, prenom = u.firstname, date_create = r.date_create, nb_like = r.nb_like, PostID = r.postID });
            return post_liste.ToList();
        }

        public LoginDTO Authentifier(string email, string password)
        {
            var logg = (from r in db.User where r.email == email && r.password == password select new LoginDTO { firstname = r.firstname, name = r.name, id_user = r.userID }).FirstOrDefault();
            return logg;

        }

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
                       select new CommentDTO { content = r.content, nom = u.name, prenom = u.firstname, nblike = r.nblike, PostID=r.postID }) ;
                return req.ToList();
        }

        public List<PostDTO> postByUserID(int UserID)
        {
            var post_liste = (
                from r in db.Post join u in db.User on r.userID equals u.userID where u.userID == UserID 
                select new PostDTO { content = r.content, nom = u.name, prenom = u.firstname, date_create = r.date_create, nb_like = r.nb_like,PostID = r.postID });
                return post_liste.ToList();
        }

    }
}
