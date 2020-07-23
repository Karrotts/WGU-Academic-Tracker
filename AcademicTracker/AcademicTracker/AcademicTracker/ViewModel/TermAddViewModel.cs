using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AcademicTracker.ViewModel
{
    public class TermAddViewModel : INotifyPropertyChanged
    {
        public TermAddViewModel()
        {
            Name = "New Term";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);

            CreateTermCommand = new Command(async () => {
                if (String.IsNullOrWhiteSpace(Name))
                {
                    await Application.Current.MainPage.DisplayAlert("Invaild Term Name", "Term name must contain at least one character.", "Ok");
                }
                else if (StartDate >= EndDate)
                {
                    await Application.Current.MainPage.DisplayAlert("Invaild Data", "Starting date must be before end date!", "Ok");
                }
                else
                {
                    Term term = new Term();
                    term.Name = Name;
                    term.StartDate = StartDate;
                    term.EndDate = EndDate;
                    DataHelper.CreateTerm(term);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command CreateTermCommand { get; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name { get; set; }
        private DateTime _startdate { get; set; }
        private DateTime _enddate { get; set; }

        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged();
            } 
        }

        public DateTime StartDate
        {
            get { return _startdate; }
            set
            {
                _startdate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _enddate; }
            set
            {
                _enddate = value;
                OnPropertyChanged();
            }
        }
    }
}
