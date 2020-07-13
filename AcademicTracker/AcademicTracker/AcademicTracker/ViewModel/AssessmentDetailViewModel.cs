using AcademicTracker.Model;
using AcademicTracker.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AcademicTracker.ViewModel
{
    public class AssessmentDetailViewModel : INotifyPropertyChanged
    {
        public AssessmentDetailViewModel()
        {
            AssessmentDeleteCommand = new Command(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to delete this assessment?", "Yes", "No"))
                {
                    CurrentCourse.Assessments.Remove(CurrentAssessment);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            });

            AssessmentEditCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushModalAsync(new AssessmentEditView());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Assessment CurrentAssessment { get; set; }
        public Course CurrentCourse { get; set; }

        public Command AssessmentDeleteCommand { get; }
        public Command AssessmentEditCommand { get; }
    }
}
