using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tchat.Core.DTO;

namespace Projet_tchat.Models
{
    public class ContactVM
    {
        public int userID { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public MessageDTO message { get; set; }
    }
}