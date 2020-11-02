using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.Models;

namespace Tchat.Core.Models
{
    public class Participants
    {
        
           [Key]
            public int id_participant { get; set; }

            [ForeignKey("User")]
            public int userID { get; set; }
            public User user { get; set; }

            [ForeignKey("Room")]
            public int roomID { get; set; }
            public Room room { get; set; }

            
    }
}
