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
        public DbSet<Campers> Campers { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        
    }
}