namespace MediaCatalog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediaType")]
    public partial class MediaType
    {
        public MediaType()
        {
            Media = new HashSet<Media>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}
