using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    [Table("terms")]
    public class TermData
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }

    [Table("courses")]
    public class CourseData
    {
    
    }

    [Table("assessments")]
    public class AssessmentData
    {
    
    }
}
