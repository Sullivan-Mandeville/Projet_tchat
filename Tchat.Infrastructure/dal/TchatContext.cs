using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tchat.Core.Models;

namespace Tchat.Infrastructure.DAL
{
    public class TchatContext : DbContext
    {

        public TchatContext() : base("TchatContext")
        {
            
        }
        

        public DbSet<User> User { get; set; }
        public DbSet<Private_message> Private_message { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<LikePost> LikePost { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();     
            
            modelBuilder.Entity<Post>()
            .HasOptional<User>(s => s.user)
            .WithRequired()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Private_message>()
            .HasOptional<User>(s => s.sender)
            .WithRequired()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Private_message>()
            .HasOptional<User>(s => s.recepient)
            .WithRequired()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<LikePost>()
           .HasOptional<User>(s => s.user)
           .WithRequired()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<LikePost>()
            .HasOptional<Post>(s => s.post)
            .WithRequired()
            .WillCascadeOnDelete(false);

       

       



        }
    }
}
