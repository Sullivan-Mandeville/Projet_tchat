using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.Models;

namespace Tchat.Infrastructure.dal
{
    public interface IDal : IDisposable
    {
        int AjouterUtilisateur(string email, string motDePasse);
        User Authentifier(string email, string motDePasse);
        User ObtenirUtilisateur(int id);
        User ObtenirUtilisateur(string idStr);
    }


   
}
