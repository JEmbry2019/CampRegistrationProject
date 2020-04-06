using CampRegistrationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CampRegistrationProject.Data
{
    //Creates a new database context named StudentInformationContext
    public class CampRegistrationProjectContext : DbContext
    {
        public CampRegistrationProjectContext(DbContextOptions<CampRegistrationProjectContext> options) : base(options)
        {
        }

        //This is where we register our models as entities
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Camper> Campers { get; set; }
    }
}