using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Models
{
    public class Post
    {
        [Key]
        public int postID { get; set; }

        public int userID { get; set; }
        public virtual User user { get; set; }

        public int categoryID { get; set; }
        public virtual Category category { get; set; }

        public String content { get; set; }
        public DateTime date_create { get; set; }
        public DateTime modification_date { get; set; }
        public virtual ICollection<User> id_user_like { get; set; }
        public int nb_like { get; set; }
    }
}
