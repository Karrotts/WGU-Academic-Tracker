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
using System.Runtime.CompilerServices;

namespace AcademicTracker.ViewModel
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        public CourseViewModel()
        {
            CourseSelectedCommand = new Command(async () => {
                if (SelectedCourse != null)
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseDetailView(new CourseDetailViewModel() { CurrentTerm = this.CurrentTerm, CurrentCourse = this.SelectedCourse }));
            });

            CourseAddCommand = new Command(async () =>
            {
                if(CurrentTerm.Courses.Count >= 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Too Many Courses", "There are too many courses in this term, please create a new term to add any additional courses or delete/modify any of the existing courses.", "Ok");
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new CourseAddView(new CourseAddViewModel() { CurrentTerm = CurrentTerm }));
                }
            });

            TermDeleteCommand = new Command(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to delete this term?", "Yes", "No"))
                {
                    DataHelper.DeleteTerm(CurrentTerm);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            });

            TermEditCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushModalAsync(new TermEditView(new TermEditViewModel(CurrentTerm) { ViewModel = this }));
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Term> TermList { get; set; }
        public Course SelectedCourse { get; set; }
        public Term CurrentTerm { get; set; }
        public Command CourseSelectedCommand { get; }
        public Command CourseAddCommand { get; }
        public Command TermDeleteCommand { get; }
        public Command TermEditCommand { get; }
    }
}
