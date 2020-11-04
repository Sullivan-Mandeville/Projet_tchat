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
        {/*
            var users = new List<User>
            {
                new User{name="Carson",firstname="Alexander",email="Alexander.Carson@hotmail.com",password="Alexander",date_create=DateTime.Parse("2020-11-03"),modification_date=DateTime.Parse("2020-11-03")},
                new User{name="Dupont",firstname="Jean",email="Jean.Dupont@hotmail.com",password="Jean",date_create=DateTime.Parse("2020-11-03"),modification_date=DateTime.Parse("2020-11-03")}
            };

            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();
*/
            var rooms = new List<Room>
            {
                new Room{name_room="tchat1"},
                new Room{name_room="tcaht2"}
            };

            rooms.ForEach(s => context.Room.Add(s));
            context.SaveChanges();

            var private_messages = new List<Private_message>
            {
                new Private_message{content="Bonjour",roomID=1,sender=null,recepient=null }

            };

            private_messages.ForEach(s => context.Private_message.Add(s));
            context.SaveChanges();

            var part = new List<Participants>
            {
               new Participants{roomID=1,userID=2},
               new Participants{roomID=2,userID=1}
            };

            part.ForEach(s => context.Participants.Add(s));
            context.SaveChanges();


            var posts = new List<Post>
            {
                new Post{userID=1,categoryID=2,content="Hello Everybody",nb_like=5,date_create=DateTime.Parse("2020-11-03"),modification_date=DateTime.Parse("2020-11-03"),status=true}
            };

            posts.ForEach(s => context.Post.Add(s));
            context.SaveChanges();

            var com = new List<Comment>
            {
               new Comment{content="Good Job",nblike=15,postID=1,userID=1}
            };

            com.ForEach(s => context.Comment.Add(s));
            context.SaveChanges();

            var cat = new List<Category>
            {
               new Category{category_title="Informatique"}
            };

            cat.ForEach(s => context.Category.Add(s));
            context.SaveChanges();

        }
    }
}