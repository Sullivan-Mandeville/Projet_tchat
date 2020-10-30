using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchat.Core.Models;

namespace Tchat.Core.Models
{
    public class User
    {
        public int id_user { get; set; }
        public String name { get; set; }
        public String firstname { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public DateTime date_create { get; set; }
        public DateTime modification_date { get; set; }
        public List<Category> liste_category { get; set; }
        public List<Room> liste_room  { get; set; }
    }
}
