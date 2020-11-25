using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Models
{
    public class Comment
    {

        [Key]
        public int commentID { get; set; }

        public String content { get; set; }

        public int postID { get; set; }
        public virtual Post post { get; set; }


        public int userID { get; set; }
        public virtual User user { get; set; }

    }
}
