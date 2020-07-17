using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AcademicTracker.ViewModel
{
    public class AssessmentAddViewModel : INotifyPropertyChanged
    {
        public AssessmentAddViewModel()
        {
            AddAssessmentCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                OnPropertyChanged();
            }
        }

        public atring Status
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
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
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
        public Course CurrentCourse { get; set; }
        public Command AddAssessmentCommand { get; set; }

        private string _Name;
        private string _Type { get; set; }
        private string _Status { get; set; }
        private DateTime _StartDate { get; set; }
        private DateTime _EndDate { get; set; }
        private bool _Notifications { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
