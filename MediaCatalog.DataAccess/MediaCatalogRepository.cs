

using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using MediaCatalog.Model;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MediaCatalog.DataAccess
{
    public class MediaCatalogRepository
    {
        private readonly EFContextProvider<MediaCatalogDbContext>
            _contextProvider = new EFContextProvider<MediaCatalogDbContext>();

        private MediaCatalogDbContext Context { get { return _contextProvider.Context; } }

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Media> Media
        {
            get { return Context.Media; }
        }

        public IQueryable<Staff> Staff
        {
            //get { return Context.Persons.Where(p => p.StaffList.Any()); }
            get { return Context.Staff; }
        }

        public IQueryable<Person> Persons
        {
            get { return Context.Person; }
        }

        public IQueryable<MediaType> MediaTypes
        {
            get { return Context.MediaType; }
        }
        public IQueryable<Role> Roles
        {
            get { return Context.Role; }
        }
        public IQueryable<Company> Companies
        {
            get { return Context.Company; }
        }


    }


}