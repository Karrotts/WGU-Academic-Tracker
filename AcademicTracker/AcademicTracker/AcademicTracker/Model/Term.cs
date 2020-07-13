using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AcademicTracker.Model
{
    public class Term
    {
        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DateString { get { return DataHelper.FormatDate(StartDate, EndDate); } }

        public Term(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
