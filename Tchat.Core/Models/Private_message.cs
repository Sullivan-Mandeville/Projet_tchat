using System;
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
        [Key]
        public int private_messageID { get; set; }

        public String content { get; set; }


        public int roomID { get; set; }
        public virtual Room room { get; set; }

        [ForeignKey("User")]
        public int senderID { get; set; }
        public virtual User sender { get; set; }


        [ForeignKey("User")] 
        public int recepientID { get; set; }
        public virtual User recepient { get; set; }
        
        
    }
}
