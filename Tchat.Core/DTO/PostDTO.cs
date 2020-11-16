using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.DTO
{
   public class PostDTO
    {
        public String nom { get; set; }
        public String prenom { get; set; }
        public String content { get; set; }
        public int nb_like { get; set; }
        public DateTime date_create { get; set; }
    }
}
