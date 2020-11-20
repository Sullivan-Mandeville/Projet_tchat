using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.DTO
{
    public class CommentDTO
    {

        public int PostID { get; set; }
        public String content { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public int nblike { get; set; }
    }
}
