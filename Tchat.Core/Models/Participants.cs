using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Model
{
    public class Participants
    {
        public int id_participant { get; set; }

        [ForeignKey("User")]
        public int id_user { get; set; }
        public User user { get; set; }

        [ForeignKey("Room")]
        public int id_room { get; set; }
        public User room { get; set; }
    }
}
