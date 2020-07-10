using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    public class Term
    {
        List<Course> Courses { get; set; }
        public string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
