using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class CourseDbContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
    }
}