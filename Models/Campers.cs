using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampRegistrationProject.Models
{
    public class Campers
    {
        public Guid ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}