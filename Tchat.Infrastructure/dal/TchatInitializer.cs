using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using Tchat.Core.Models;

namespace Tchat.Infrastructure.DAL
{
    public class TchatInitializer : DropCreateDatabaseIfModelChanges<TchatContext>
    {
        protected override void Seed(TchatContext context)
        {
            var user = new List<User>
            {
            new User{name="test",firstname="test",email="test",password="test",date_create=DateTime.Parse("2005-09-01"), modification_date=DateTime.Parse("2005-09-01")}
            };

            user.ForEach(s => context.User.Add(s));
            context.SaveChanges();

        }
    }
}