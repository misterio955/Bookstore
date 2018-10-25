using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Bookstore.DBModels;

namespace Bookstore.Context
{
    public class BookstoreContext : DbContext
    {
         
        public virtual DbSet<DBUser> Users { get; set; }
        public virtual DbSet<DBBook> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer<BookstoreContext>(null);

            modelBuilder.Entity<DBUser>().HasKey(x => x.UserID).HasIndex(x => x.UserID);
            modelBuilder.Entity<DBUser>().ToTable("Users");
            modelBuilder.Entity<DBUser>().Property(x => x.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DBBook>().HasKey(x => x.BookID).HasIndex(x => x.BookID);
            modelBuilder.Entity<DBBook>().ToTable("Books");
            modelBuilder.Entity<DBBook>().Property(x => x.BookID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}