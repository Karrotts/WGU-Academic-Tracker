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
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int term_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool notifications { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string instructor_name { get; set; }
        public string instructor_email { get; set; }
        public string instructor_phone { get; set; }
        public string notes { get; set; }
    }

    [Table("assessments")]
    public class AssessmentData
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int course_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool notifications { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string status { get; set; }
    }
}
