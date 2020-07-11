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
                    await Application.Current.MainPage.Navigation.PushAsync();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Term CurrentTerm { get; set; }
        public Course SelectedCourse { get; set; }
        public string TermTitle { get { return DataHelper.TitleLimitor(CurrentTerm.Name, 25); } }

        public Command CourseSelectedCommand { get; }
    }
}
