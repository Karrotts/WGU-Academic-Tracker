using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    public class Term
    {
        public List<Course> Courses = new List<Course>();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Term(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
