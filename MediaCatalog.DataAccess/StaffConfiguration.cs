using System.Data.Entity.ModelConfiguration;
using MediaCatalog.Model;

namespace MediaCatalog.DataAccess
{
    public class StaffConfiguration: EntityTypeConfiguration<Staff>
    {
        public StaffConfiguration()
        {
            // Staff has a composite key: MediaId and PersonId
            HasKey(a => new { a.MediaId, a.PersonId });

            // Staff has 1 Media, Media have many Staff records
            HasRequired(a => a.Media)
                .WithMany(s => s.StaffList)
                .HasForeignKey(a => a.MediaId)
                .WillCascadeOnDelete(false);

            // Staff has 1 Person, Persons have many Staff records
            HasRequired(a => a.Person)
                .WithMany(p => p.StaffList)
                .HasForeignKey(a => a.PersonId)
                .WillCascadeOnDelete(false);
        }
 
    }
      
}