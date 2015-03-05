
using System.Collections.Generic;

namespace MediaCatalog.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Staff> StaffList { get; set; }
        //public virtual ICollection<Media> MediaList { get; set; }
    }
}
