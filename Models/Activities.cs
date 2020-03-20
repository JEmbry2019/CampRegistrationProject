using System;
using System.Collections.Generic;

namespace CampRegistrationProject.Models
{
    public class Activities
    {
        public Guid ID { get; set; }
        public string Sport { get; set; }
        public string Game { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}