using Microsoft.EntityFrameworkCore;

namespace RelationUsingConventions
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=.\;database=BooksConv;trusted_connection=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
