using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
