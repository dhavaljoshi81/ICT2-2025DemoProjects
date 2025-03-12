using System;
using System.Collections.Generic;

namespace ICT2StudentDemoWebAPICS.Models;

public partial class Subject
{
    public int SubjectCode { get; set; }

    public string Title { get; set; } = null!;

    public int InternalMarks { get; set; }

    public int ExternalMarks { get; set; }

    public int TotalMarks { get; set; }

    public virtual ICollection<Student> EnrollmentNos { get; set; } = new List<Student>();
}
