using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

namespace AcademicTracker.Model
{
    [Table("assessment")]
    public class Assessment : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                AssessmentCommonName = value;
                AssessmentLongName = value;
                OnPropertyChanged();
            }
        }

        public AssessmentType Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                OnPropertyChanged();
            }
        }

        public AssessmentStatus Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
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

        public bool Notifications
        {
            get { return _Notifications; }
            set
            {
                _Notifications = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string DateString { get { return DataHelper.FormatDate(StartDate, EndDate); } set { OnPropertyChanged(); } }
        public string AssessmentCommonName { get { return Type.ToString() + " Assessment"; } set { OnPropertyChanged(); } }
        public string AssessmentLongName { get { return AssessmentCommonName + ": " + Name; } set { OnPropertyChanged(); } }

        private string _Name;
        private AssessmentType _Type { get; set; }
        private AssessmentStatus _Status { get; set; }
        private DateTime _StartDate { get; set; }
        private DateTime _EndDate { get; set; }
        private bool _Notifications { get; set; }

        public Assessment(string name, AssessmentType type, AssessmentStatus status = AssessmentStatus.New)
        {
            Name = name;
            Type = type;
            Status = status;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum AssessmentType
    {
        Objective  = 0,
        Peformance = 1
    }

    public enum AssessmentStatus
    {
        New    = 0,
        Passed = 1,
        Failed = 2
    }
}
