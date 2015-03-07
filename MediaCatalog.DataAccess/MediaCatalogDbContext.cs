using MediaCatalog.Model;
using System.Data.Entity;

namespace MediaCatalog.DataAccess
{
    public partial class MediaCatalogDbContext : DbContext
    {
        public MediaCatalogDbContext()
            : base("name=MediaCatalogDbContext")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>()
                .HasMany(e => e.Staff)
                .WithRequired(e => e.Media)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Staff)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);
        }
    }
}
