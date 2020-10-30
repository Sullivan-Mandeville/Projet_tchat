using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.Models;

namespace Tchat.Core.Models
{
    public class Participants
    {
      public int id_participant { get; set; }

        public List<User> liste_user { get; set; }

        [ForeignKey("Room")]
        public int id_room { get; set; }
        public User room { get; set; }
       
    }
}
