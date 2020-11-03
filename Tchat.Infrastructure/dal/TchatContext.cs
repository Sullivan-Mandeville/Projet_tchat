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
        public DbSet<Room> Room { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}