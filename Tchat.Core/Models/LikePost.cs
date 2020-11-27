using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Models
{
    public class LikePost
    {
        [Key, Column (Order=0)]
        [ForeignKey("post")]
        public int postID { get; set; }
        [Key, Column (Order=1)]  
        [ForeignKey("user")]
        public int userID { get; set; }

        
        public virtual User user { get; set; }
      
        public virtual Post post { get; set; }

        public LikePost(int userID, int postID)
        {
            this.userID = userID;
            this.postID = postID;
        }
    }

    
}
