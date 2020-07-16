using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AcademicTracker.Model
{
    public class Course : INotifyPropertyChanged
    {
        public ObservableCollection<Assessment> Assessments = new ObservableCollection<Assessment>();

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                DateString = _StartDate.ToString();
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                DateString = _EndDate.ToString();
                OnPropertyChanged();
            }
        }

        public CourseStatus Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }

        public bool Notifications
        {
            get { return _Notifications; }
            set
            {
                _Notifications = value;
                OnPropertyChanged();
            }
        }

        public string InstructorName
        {
            get { return _InstructorName; }
            set
            {
                _InstructorName = value;
                OnPropertyChanged();
            }
        }

        public string InstructorEmail
        {
            get { return _InstructorEmail; }
            set
            {
                _InstructorEmail = value;
                OnPropertyChanged();
            }
        }

        public string InstructorPhone
        {
            get { return _InstructorPhone; }
            set
            {
                _InstructorPhone = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
                OnPropertyChanged();
            }
        }

        public string DateString { get { return DataHelper.FormatDate(StartDate, EndDate); } set { OnPropertyChanged(); } }

        private string _Title { get; set; }
        private DateTime _StartDate { get; set; }
        private DateTime _EndDate { get; set; }
        private CourseStatus _Status { get; set; }
        private bool _Notifications { get; set; }
        private string _InstructorName { get; set; }
        private string _InstructorPhone { get; set; }
        private string _InstructorEmail { get; set; }
        private string _Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum CourseStatus
    {
        New        = 0,
        Inprogress = 1,
        Completed  = 2,
        Failed     = 3
    }
}
