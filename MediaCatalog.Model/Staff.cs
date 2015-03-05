namespace MediaCatalog.Model
{
    public class Staff
    {

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}