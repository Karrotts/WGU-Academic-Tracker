using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    class Course
    {
        List<Assessment> Assessments { get; set; }
        string Title { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        CourseStatus Status { get; set; }
        string InstructorName { get; set; }
        string InstructorEmail { get; set; }
        string InstructorPhone { get; set; }
        string Notes { get; set; }
    }

    internal enum CourseStatus
    {
        New        = 0,
        Inprogress = 1,
        Completed  = 2,
        Failed     = 3
    }
}
