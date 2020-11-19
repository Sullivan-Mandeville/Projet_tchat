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

        public User ObtenirUtilisateur(int id)
        {
            throw new NotImplementedException();
        }

        public User ObtenirUtilisateur(string idStr)
        {
            throw new NotImplementedException();
        }

        public List<PostDTO> post(int id)
        {
            var post_liste = (
                from r in db.Post join u in db.User on r.userID equals u.userID where u.userID == id 
                select new PostDTO { content = r.content, nom = u.name, prenom = u.firstname, date_create = r.date_create, nb_like = r.nb_like });
                return post_liste.ToList();
        }

    }
}
