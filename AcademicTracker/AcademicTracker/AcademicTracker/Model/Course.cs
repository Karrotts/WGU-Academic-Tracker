using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    public class Course
    {
        public List<Assessment> Assessments = new List<Assessment>();
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CourseStatus Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPhone { get; set; }
        public string Notes { get; set; }
        public string DateString { get { return DataHelper.FormatDate(StartDate, EndDate); } }
    }

    public enum CourseStatus
    {
        New        = 0,
        Inprogress = 1,
        Completed  = 2,
        Failed     = 3
    }
}
