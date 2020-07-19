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
    public class AssessmentAddViewModel : INotifyPropertyChanged
    {
        public AssessmentAddViewModel()
        {
            Name = "New Assessment";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            Type = "Objective";
            Status = "New";
            Notifications = true;

            AddAssessmentCommand = new Command(async () => {

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
                else if (DataHelper.ConvertAssessmentType(Type) == AssessmentType.Objective && CurrentCourse.Assessments.Where(type => type.Type == AssessmentType.Objective).Count() >= 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Type", "Assessment type already exists. Assessment must be of type performance.", "Ok");
                }
                else if (DataHelper.ConvertAssessmentType(Type) == AssessmentType.Peformance && CurrentCourse.Assessments.Where(type => type.Type == AssessmentType.Peformance).Count() >= 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Type", "Assessment type already exists. Assessment must be of type objective.", "Ok");
                }
                else
                {
                    Assessment assessment = new Assessment(Name, DataHelper.ConvertAssessmentType(Type), DataHelper.ConvertAssessmentStatus(Status));
                    assessment.StartDate = StartDate;
                    assessment.EndDate = EndDate;
                    assessment.Notifications = Notifications;

                    DataHelper.CreateAssessment(assessment, CurrentCourse);
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
