using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AcademicTracker.ViewModel
{
    public class AssessmentEditViewModel : INotifyPropertyChanged
    {
        public AssessmentEditViewModel(Assessment assessment)
        {
            SaveAssessmentCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Course CurrentCourse { get; set; }
        public Assessment CurrentAssessment { get; set; }
        public Command SaveAssessmentCommand { get; set; }
    }
}
