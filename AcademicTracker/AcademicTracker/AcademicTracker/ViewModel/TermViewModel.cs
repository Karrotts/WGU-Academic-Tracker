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
            Terms = new ObservableCollection<Term>();

            Terms.Add(new Term { Name = "Term 1 (Current)"});
            Terms.Add(new Term { Name = "Term 2" });
            Terms.Add(new Term { Name = "Term 3" });
            Terms.Add(new Term { Name = "Term 4" });
            Terms.Add(new Term { Name = "Term 5" });
            Terms.Add(new Term { Name = "Term 6" });
            Terms.Add(new Term { Name = "Term 7" });

            TermSelectedCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new CourseView(new CourseViewModel { CurrentTerm = SelectedTerm })));
            AddNewTermCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new AddTermView()));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<Term> Terms { get; }
        public Term SelectedTerm { get; set; }

        public Command TermSelectedCommand { get; }
        public Command AddNewTermCommand { get;  }
    }
}
