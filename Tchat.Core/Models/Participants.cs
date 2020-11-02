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
        public int participantsID { get; set; }

     
            public int userID { get; set; }
            public virtual User user { get; set; }

       
            public int roomID { get; set; }
            public virtual Room room { get; set; }

            
    }
}
