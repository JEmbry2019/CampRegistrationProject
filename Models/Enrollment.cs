using System;

namespace CampRegistrationProject.Models
{
    public enum Menu
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public Guid ID { get; set; }
        public Guid MealsID { get; set; }
        public Guid CampersID { get; set; }
        public Menu? Menu { get; set; }

        public Guid ActivitiesID {get; set;}
       
        public Campers Campers { get; set; }
        public Activities Activities { get; set; }
        public Meals Meals { get; set; }
    }
}