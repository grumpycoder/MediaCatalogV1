using MediaCatalog.Model;
using System;

namespace MediaCatalog.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MediaCatalog.DataAccess.MediaCatalogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MediaCatalog.DataAccess.MediaCatalogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Persons.AddOrUpdate(
              p => p.LastName,
              new Person { LastName = "Andrew", FirstName = "Peters" },
              new Person { LastName = "Brice", FirstName = "Lambson" },
              new Person { LastName = "Rowan", FirstName = "Miller" }
            );
            context.SaveChanges();

            context.Companies.AddOrUpdate(
                c => c.Name,
                new Company { Id = 1, Name = "Research Press Company, Inc." },
                new Company { Id = 2, Name = "Independent Publishers Group" },
                new Company { Id = 3, Name = "New York University Press" },
                new Company { Id = 4, Name = "University of Washington Press" }
            );
            context.SaveChanges();

            context.MediaTypes.AddOrUpdate(
                t => t.Name,
                new MediaType { Id = 1, Name = "Book" },
                new MediaType { Id = 2, Name = "Audio" },
                new MediaType { Id = 3, Name = "Video" }
                );
            context.SaveChanges();

            context.Media.AddOrUpdate(
                m => m.Title,
                new Media { Title = "Schools Where Everyone Belongs", ISBN = "0-87822-584-6", MediaTypeId = 1, CompanyId = 1, ReceiptDate = new DateTime(2012, 2, 5) },
                new Media { Title = "Cyberbullying and Cyberthreats", ISBN = "0-87822-537-4", MediaTypeId = 2, CompanyId = 2, ReceiptDate = new DateTime(2013, 8, 10) },
                new Media { Title = "Religious Literacy", ISBN = "978-0-06-084670-1", MediaTypeId = 3, CompanyId = 1, ReceiptDate = new DateTime(2014, 4, 12) },
                new Media { Title = "The Boy and the Spell", ISBN = "978-0-9646010-4-8", MediaTypeId = 1, CompanyId = 2, ReceiptDate = new DateTime(2011, 6, 15) }
                );
            context.SaveChanges();
        }
    }
}
