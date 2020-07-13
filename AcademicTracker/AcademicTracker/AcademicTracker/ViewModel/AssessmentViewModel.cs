using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AcademicTracker.ViewModel
{
    public class AssessmentViewModel : INotifyPropertyChanged
    {
        public AssessmentViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Course CurrentCourse { get; set; }
    }
}
