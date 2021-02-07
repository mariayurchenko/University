using System;
using System.Collections.Generic;
using System.Text;
using myProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;

namespace RazorPagesTestSample.Tests
{
    static class Utilities
    {
     /*   public Utilities()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase("InMemoryDb");

            using (var db = new AppDBContent(optionsBuilder.Options))
            {
                // Use the db here in the unit test.
            }
        }  */
        public static DbContextOptions<AppDBContent> TestDbContextOptions()
        {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

    }
}
