using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tchat.Core.DTO;

namespace Projet_tchat.Models
{
    public class PostVM
    {
        public int PostID { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String content { get; set; }

        public DateTime date_create { get; set; }

        public List<CommentDTO> Comments { get; set; }

    }
}