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
    public class CourseDetailViewModel : INotifyPropertyChanged
    {
        public CourseDetailViewModel()
        {
            ShareCommand = new Command(async () => await ShareText());
            AssessmentDetailsCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AssessmentView()));
        }

        public async Task ShareText()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = CurrentCourse.Notes,
                Title = CurrentCourse.Title + " Notes"
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Term CurrentTerm { get; set; }
        public Course CurrentCourse { get; set; }
        public string CourseTitle { get {  return DataHelper.TitleLimitor(CurrentCourse.Title, 20); } }
        
        public Command ShareCommand { get; }
        public Command AssessmentDetailsCommand { get; }
    }
}
