using System;
using System.Collections.Generic;

namespace CollegeAPI.Models;

public partial class StudentsT
{
    public int StudentIdNum { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public virtual Hostel? Hostel { get; set; }
}
