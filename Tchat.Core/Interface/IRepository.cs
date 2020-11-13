using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.DTO;
using Tchat.Core.Models;

namespace Tchat.Infrastructure.dal
{
    public interface IRepository
    {
        LoginDTO Authentifier(string email, string password);
        User ObtenirUtilisateur(int id);
        User ObtenirUtilisateur(string idStr);
        LoginDTO list_user();
    }


   
}
