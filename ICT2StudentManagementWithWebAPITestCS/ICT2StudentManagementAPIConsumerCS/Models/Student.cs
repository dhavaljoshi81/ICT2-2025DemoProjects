using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ICT2StudentManagementAPIConsumerCS.Models
{
    public class Student
    {
        public int EnrollmentNo { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd:mm:yyyy", ApplyFormatInEditMode = true)]
        public DateOnly DateOfBirth { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string? Achievement { get; set; }
    }
}
