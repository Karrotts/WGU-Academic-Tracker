using AcademicTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AcademicTracker.ViewModel
{
    public class CourseAddViewModel : INotifyPropertyChanged
    {
        public CourseAddViewModel()
        {
            Title = "New Course";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            Status = "New";
            Notifications = true;

            CreateCourseCommand = new Command(async () =>
            {
                if(String.IsNullOrWhiteSpace(Title))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Title must contain at least one character.", "Ok");
                }
                else if (StartDate >= EndDate)
                {
                    await Application.Current.MainPage.DisplayAlert("Invaild Data", "Starting date must be before end date!", "Ok");
                }
                else if (String.IsNullOrWhiteSpace(Status))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Course status must be selected.", "Ok");
                }
                else if (String.IsNullOrWhiteSpace(InstructorName))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Instructor Name must contain at least one character", "Ok");
                }
                else if (String.IsNullOrWhiteSpace(InstructorEmail) || !DataHelper.IsValidEmail(String.IsNullOrWhiteSpace(InstructorEmail) ? " " : InstructorEmail))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Invalid email addess entered or email address was empty.", "Ok");
                }
                else if (String.IsNullOrWhiteSpace(InstructorEmail) || !DataHelper.IsPhoneNumber(String.IsNullOrWhiteSpace(InstructorPhone) ? " " : InstructorPhone))
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Data", "Invalid phone number or phone number was empty.", "Ok");
                }
                else
                {
                    Course course = new Course();
                    course.Title = Title;
                    course.StartDate = StartDate;
                    course.EndDate = EndDate;
                    course.Status = DataHelper.ConvertCourseStatus(Status);
                    course.Notifications = Notifications;
                    course.InstructorName = InstructorName;
                    course.InstructorEmail = InstructorEmail;
                    course.InstructorPhone = InstructorPhone;
                    course.Notes = Notes;
                    DataHelper.CreateCourse(course, CurrentTerm);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command CreateCourseCommand { get; set; }
        public Term CurrentTerm { get; set; }

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

        public string Status
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

        private string _Title { get; set; }
        private DateTime _StartDate { get; set; }
        private DateTime _EndDate { get; set; }
        private string _Status { get; set; }
        private bool _Notifications { get; set; }
        private string _InstructorName { get; set; }
        private string _InstructorPhone { get; set; }
        private string _InstructorEmail { get; set; }
        private string _Notes { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
