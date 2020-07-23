using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace AcademicTracker.Model
{
    public class Term : INotifyPropertyChanged
    {
        public int ID { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                TermTitle = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                DateString = value.ToString();
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                DateString = value.ToString();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();

        public string DateString { get { return DataHelper.FormatDate(StartDate, EndDate); } set { OnPropertyChanged(); } }
        public string TermTitle { get { return DataHelper.TitleLimitor(Name, 20); } set { OnPropertyChanged(); } }

        private string _name;
        private DateTime _StartDate;
        private DateTime _EndDate;

        public Term(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
