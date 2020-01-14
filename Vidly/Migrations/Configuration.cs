namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.Models.MyDbContext context)
        {
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.MembershipTypes.AddOrUpdate(
            //    p => p.SignUpFee,
            //    new MembershipType
            //    {
            //        Id = 1,
            //        Name = "Pay as You Go",
            //        SignUpFee = 0,
            //        DurationInMonths = 0,
            //        DiscountRate = 0
            //    },
            //    new MembershipType
            //    {
            //        Id = 2,
            //        Name = "Monthly",
            //        SignUpFee = 30,
            //        DurationInMonths = 1,
            //        DiscountRate = 10
            //    },
            //    new MembershipType
            //    {
            //        Id = 3,
            //        Name = "Quarterly",
            //        SignUpFee = 90,
            //        DurationInMonths = 3,
            //        DiscountRate = 15
            //    },
            //    new MembershipType
            //    {
            //        Id = 4,
            //        Name = "Annual",
            //        SignUpFee = 300,
            //        DurationInMonths = 3,
            //        DiscountRate = 15
            //    }
            //    );

            //context.Customers.AddOrUpdate(
            //    c => c.Name,
            //    new Customer
            //    {
            //        Id = 1,
            //        Name = "John Smith",
            //        IsSubscribedToNewsletter = false,
            //        MembershipTypeId = 1,
            //        Birthdate = new DateTime(1991, 6, 13)
            //    },
            //    new Customer
            //    {
            //        Id = 2,
            //        Name = "Don Joe",
            //        IsSubscribedToNewsletter = true,
            //        MembershipTypeId = 2
            //    }
            //    );

            //context.Genres.AddOrUpdate(
            //    g => g.Name,
            //    new Genre { Id = 1, Name = "Comedy" },
            //    new Genre { Id = 2, Name = "Action" },
            //    new Genre { Id = 3, Name = "Family" },
            //    new Genre { Id = 4, Name = "Romance" }
            //    );

            //context.Movies.AddOrUpdate(
            //    m => m.Name,
            //    new Movie
            //    {
            //        Id = 1,
            //        Name = "Hangover",
            //        ReleaseDate = new DateTime(2009, 11, 6),
            //        DateAdded = new DateTime(2016, 5, 4),
            //        NumberInStock = 5,
            //        GenreId = 1
            //    },
            //     new Movie
            //     {
            //         Id = 2,
            //         Name = "Die Hard",
            //         ReleaseDate = new DateTime(2009, 11, 6),
            //         DateAdded = new DateTime(2016, 5, 4),
            //         NumberInStock = 3,
            //         GenreId = 2
            //     },
            //     new Movie
            //     {
            //         Id = 3,
            //         Name = "The Terminator",
            //         ReleaseDate = new DateTime(2009, 11, 6),
            //         DateAdded = new DateTime(2016, 5, 4),
            //         NumberInStock = 1,
            //         GenreId = 2
            //     },
            //     new Movie
            //     {
            //         Id = 4,
            //         Name = "Toy Story",
            //         ReleaseDate = new DateTime(2009, 11, 6),
            //         DateAdded = new DateTime(2016, 5, 4),
            //         NumberInStock = 5,
            //         GenreId = 3
            //     },
            //     new Movie
            //     {
            //         Id = 5,
            //         Name = "Titanic",
            //         ReleaseDate = new DateTime(2009, 11, 6),
            //         DateAdded = new DateTime(2016, 5, 4),
            //         NumberInStock = 3,
            //         GenreId = 4
            //     }
            //    );
        }
    }
}
