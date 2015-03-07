namespace MediaCatalog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
