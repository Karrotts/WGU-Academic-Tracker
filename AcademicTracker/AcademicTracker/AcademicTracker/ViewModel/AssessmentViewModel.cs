using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AcademicTracker.View;
using System.Collections.ObjectModel;
using AcademicTracker.Model;


namespace AcademicTracker.ViewModel
{
    public class AssessmentViewModel : INotifyPropertyChanged
    {
        public AssessmentViewModel()
        {
            AssessmentSelectedCommand = new Command(async () => {
                if (SelectedAssessment != null)
                    await Application.Current.MainPage.Navigation.PushAsync(new AssessmentDetailView(new AssessmentDetailViewModel() { CurrentCourse = CurrentCourse, CurrentAssessment = SelectedAssessment }));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Course CurrentCourse { get; set; }
        public Assessment SelectedAssessment { get; set; }
        public Command AssessmentSelectedCommand { get; }
    }
}
