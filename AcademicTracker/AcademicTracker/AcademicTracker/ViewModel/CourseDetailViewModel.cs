using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AcademicTracker.ViewModel
{
    public class CourseDetailViewModel : INotifyPropertyChanged
    {
        public CourseDetailViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Term CurrentTerm { get; set; }
        public Course CurrentCourse { get; set; }
        public string CourseTitle { get {  return DataHelper.TitleLimitor(CurrentCourse.Title, 20); } }
    }
}
