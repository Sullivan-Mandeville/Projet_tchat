using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using Tchat.Core.Models;

namespace Tchat.Infrastructure.DAL
{
    public class TchatInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TchatContext>
    {
        protected override void Seed(TchatContext context)
        {
            var users = new List<User>
            {
                new User{name="Carson",firstname="Alexander",email="Alexander.Carson@hotmail.com",password="Alexander",date_create=DateTime.Parse("2020-11-03"),modification_date=DateTime.Parse("2020-11-03"),liste_category=null,liste_room=null}

            };

            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();
        }
    }
}