using Breeze.ContextProvider;
using Breeze.WebApi2;
using MediaCatalog.DataAccess;
using MediaCatalog.Model;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web.Http;

namespace MediaCatalog.Web.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {

        public BreezeController()
        {

        }

        // Todo: inject via an interface rather than "new" the concrete class
        readonly MediaCatalogRepository repository = new MediaCatalogRepository();

        [HttpGet]
        public string Metadata()
        {
            return repository.Metadata;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Media> Media()
        {
            return repository.Media;
        }

        [HttpGet]
        public IQueryable<Staff> Staff()
        {
            return repository.Staff;
        }

        [HttpGet]
        public IQueryable<Person> Persons()
        {
            return repository.Persons;
        }

        [HttpGet]
        public IQueryable<Company> Companies()
        {
            return repository.Companies;
        }

        /// <summary>
        /// Query returing a 1-element array with a lookups object whose 
        /// properties are all Rooms, Tracks, and TimeSlots.
        /// </summary>
        /// <returns>
        /// Returns one object, not an IQueryable, 
        /// whose properties are "rooms", "tracks", "timeslots".
        /// The items arrive as arrays.
        /// </returns>
        [HttpGet]
        public object Lookups()
        {
            var mediaTypes = repository.MediaTypes;
            var roles = repository.Roles;
            return new { roles, mediaTypes };
        }

        // Diagnostic
        [HttpGet]
        public string Ping()
        {
            return "pong";
        }
    }
}