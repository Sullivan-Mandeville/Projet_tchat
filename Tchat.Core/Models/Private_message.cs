﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Models
{
    public class Private_message
    {
        
        public int id_private_message { get; set; }

        public String content { get; set; }

        [ForeignKey("Room")]
        public int id_room { get; set; }
        public Room room { get; set; }

        [ForeignKey("User")]
        public int id_sender { get; set; }
        public User sender { get; set; }

        [ForeignKey("User")]
        public int id_recepient { get; set; }
        public User recepient { get; set; }
        
        
    }
}
