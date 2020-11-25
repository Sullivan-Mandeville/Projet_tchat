using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.DTO
{
    public class MessageDTO
    {
        public String nom { get; set; }
        public String prenom { get; set; }
        public DateTime date_message { get; set; }
        public String content { get; set; }
        public int id_sender { get; set; }


    }
}
