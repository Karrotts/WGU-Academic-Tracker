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
    class TermViewModel : INotifyPropertyChanged
    {
        public TermViewModel()
        {
            TermSelectedCommand = new Command(async () => {
                if (SelectedTerm != null)
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseView(new CourseViewModel { CurrentTerm = SelectedTerm, TermList = DataHelper.DataStore }));
            });
            AddNewTermCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new TermAddView(new TermAddViewModel())));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Term SelectedTerm { get; set; }

        public Command TermSelectedCommand { get; }
        public Command AddNewTermCommand { get;  }
    }
}
