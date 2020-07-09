using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    class Term
    {
        List<Course> Courses { get; set; }
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
