﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Models
{
    public class Room
    {
        [Key]
        public int roomID { get; set; }
        public String name_room { get; set; }
        
    }
}
