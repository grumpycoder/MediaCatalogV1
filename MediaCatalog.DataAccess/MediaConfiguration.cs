using MediaCatalog.Model;
using System.Data.Entity.ModelConfiguration;

namespace MediaCatalog.DataAccess
{
    public class MediaConfiguration : EntityTypeConfiguration<Media>
    {
        public MediaConfiguration()
        {
            // Session has 1 Speaker, Speaker has many Session records
            HasRequired(s => s.Company);
            //   .WithMany(p => p.SpeakerSessions)
            //   .HasForeignKey(s => s.SpeakerId);
        }
    }
}