using System;
using System.Collections.Generic;

namespace CampRegistrationProject.Models
{
    public class Meals
    {
        public Guid ID { get; set; }
        public string Menu { get; set; }
        public int Perday { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}