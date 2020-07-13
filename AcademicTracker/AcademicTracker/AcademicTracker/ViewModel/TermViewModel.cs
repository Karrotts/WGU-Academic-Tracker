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
using AcademicTracker.Test;

namespace AcademicTracker.ViewModel
{
    class TermViewModel : INotifyPropertyChanged
    {
        public TermViewModel()
        {
            Terms = new ObservableCollection<Term>();

            // Generate generic test data
            Terms.Add(DummyData.Generate("Term 1 (Current)"));

            TermSelectedCommand = new Command(async () => {
                if (SelectedTerm != null)
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseView(new CourseViewModel { CurrentTerm = SelectedTerm, TermList = Terms }));
            });
            AddNewTermCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new TermAddView()));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<Term> Terms { get; }
        public Term SelectedTerm { get; set; }

        public Command TermSelectedCommand { get; }
        public Command AddNewTermCommand { get;  }
    }
}
