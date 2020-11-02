using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchat.Core.Models
{
    public class Post
    {
        public int id_post { get; set; }
        [ForeignKey("User")]
        public int id_user { get; set; }
        [ForeignKey("Category")]
        public int id_category { get; set; }
        public String content { get; set; }
        public DateTime date_create { get; set; }
        public DateTime modification_date { get; set; }
        public Boolean status { get; set; }
        public virtual ICollection<User> id_user_like { get; set; }
       // public int nb_like { get; set; }
    }
}
