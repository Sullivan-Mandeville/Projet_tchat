﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.Models;

namespace Tchat.Core.Models
{
    public class User
    {
      [Key]
        public int userID { get; set; }

        public String name { get; set; }
        public String firstname { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public DateTime date_create { get; set; }
        public DateTime modification_date { get; set; }



        [InverseProperty(nameof(Private_message.sender))]
        public ICollection<Private_message> sent_message  { get; set; }

        [InverseProperty(nameof(Private_message.recepient))]
        public ICollection<Private_message> received_message { get; set; }


    }
}
