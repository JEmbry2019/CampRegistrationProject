using System;

namespace CampRegistrationProject.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public Guid ID { get; set; }
        public Guid CourseID { get; set; }
        public Guid CamperID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Camper Camper { get; set; }
    }
}