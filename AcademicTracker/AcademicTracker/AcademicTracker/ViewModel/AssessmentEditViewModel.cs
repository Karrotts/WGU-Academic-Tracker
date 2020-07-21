using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AcademicTracker.ViewModel
{
    public class AssessmentEditViewModel : INotifyPropertyChanged
    {
        public AssessmentEditViewModel(Assessment assessment)
        {
            Name = assessment.Name;
            StartDate = assessment.StartDate;
            EndDate = assessment.EndDate;
            Type = assessment.Type.ToString();
            Status = assessment.Status.ToString();
            Notifications = assessment.Notifications;

            SaveAssessmentCommand = new Command(async () => {
                if (String.IsNullOrWhiteSpace(Name))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Assessment name must contain at least one character", "Ok");
                }
                else if (String.IsNullOrWhiteSpace(Type) || String.IsNullOrWhiteSpace(Status))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Assessment name must contain at least one character", "Ok");
                }
                else if (StartDate >= EndDate)
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Date", "Start date must be before end date.", "Ok");
                }
                else if (CurrentCourse.Assessments.Count >= 2 && CurrentAssessment.Type != DataHelper.ConvertAssessmentType(Type))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Type", "Unable to change assessment type, all current assessment types are taken.", "Ok");
                }
                else
                {
                    CurrentAssessment.Name = Name;
                    CurrentAssessment.StartDate = StartDate;
                    CurrentAssessment.EndDate = EndDate;
                    CurrentAssessment.Status = DataHelper.ConvertAssessmentStatus(Status);
                    CurrentAssessment.Type = DataHelper.ConvertAssessmentType(Type);
                    CurrentAssessment.Notifications = Notifications;

                    DataHelper.UpdateAssessment(CurrentAssessment, CurrentCourse);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
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

        public string Status
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
        public Assessment CurrentAssessment { get; set; }
        public Command SaveAssessmentCommand { get; set; }

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
