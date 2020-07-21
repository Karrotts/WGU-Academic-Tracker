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

            AssessmentAddCommand = new Command(async () =>
            {
                if(CurrentCourse.Assessments.Count >= 2)
                {
                    await Application.Current.MainPage.DisplayAlert("Too Many Assessments", "Unable to add any additional Assessments. Limit 2.", "Ok");
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new AssessmentAddView(new AssessmentAddViewModel() { CurrentCourse = CurrentCourse }));
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Course CurrentCourse { get; set; }
        public Assessment SelectedAssessment { get; set; }
        public Command AssessmentSelectedCommand { get; }
        public Command AssessmentAddCommand { get;  }
    }
}
