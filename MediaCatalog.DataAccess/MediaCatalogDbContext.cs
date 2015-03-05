using MediaCatalog.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MediaCatalog.DataAccess
{
    public class MediaCatalogDbContext : DbContext
    {
        public MediaCatalogDbContext()
            : base(nameOrConnectionString: "MediaCatalog")
        {

        }

        static MediaCatalogDbContext()
        {
            Database.SetInitializer<MediaCatalogDbContext>(new DropCreateDatabaseIfModelChanges<MediaCatalogDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Disable proxy creation and lazy loading; not wanted in this service context.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            modelBuilder.Configurations.Add(new MediaConfiguration());
            modelBuilder.Configurations.Add(new StaffConfiguration());



        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Staff> Staff { get; set; }

        // Lookup Lists
        public DbSet<Role> Roles { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
    }
}