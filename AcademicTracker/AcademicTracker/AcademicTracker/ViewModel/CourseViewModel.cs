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
                await Application.Current.MainPage.Navigation.PushModalAsync(new CourseAddView());
            });

            TermDeleteCommand = new Command(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to delete this term?", "Yes", "No"))
                {
                    TermList.Remove(CurrentTerm);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            });

            TermEditCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushModalAsync(new TermEditView());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Term> TermList { get; set; }
        public Term CurrentTerm { get; set; }
        public Course SelectedCourse { get; set; }
        public string TermTitle { get { return DataHelper.TitleLimitor(CurrentTerm.Name, 20); } }

        public Command CourseSelectedCommand { get; }
        public Command CourseAddCommand { get; }
        public Command TermDeleteCommand { get; }
        public Command TermEditCommand { get; }
    }
}
