using System;
using System.Collections.Generic;

namespace ICT2StudentDemoWebAPICS.Models;

public partial class Student
{
    public int EnrollmentNo { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? Achievement { get; set; }

    public virtual ICollection<Subject> SubjectCodes { get; set; } = new List<Subject>();
}
