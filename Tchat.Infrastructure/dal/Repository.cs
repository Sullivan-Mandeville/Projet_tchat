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
            var logg = (from r in db.User where r.email == email && r.password == password select new LoginDTO { firstname = r.firstname,name= r.name,id_user= r.userID } ).FirstOrDefault();
            return logg;
        
         }

        public User ObtenirUtilisateur(int id)
        {
            throw new NotImplementedException();
        }

        public User ObtenirUtilisateur(string idStr)
        {
            throw new NotImplementedException();
        }
    }
}
