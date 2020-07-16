using AcademicTracker.Model;
using AcademicTracker.Test;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace AcademicTracker
{
    public static class DataHelper
    {
        public static ObservableCollection<Term> DataStore = new ObservableCollection<Term>();

        public static void Initalize()
        {
            DataStore.Add(DummyData.Generate("Starting Term"));
        }

        public static void CreateTerm(Term term)
        {
            DataStore.Add(term);
            //Add term into database
        }

        public static void UpdateTerm(Term term)
        {
            //Just need to update the database here
        }

        public static void DeleteTerm(Term term)
        {
            DataStore.Remove(term);
            //remove term from database
        }

        public static void CreateCourse(Course course, Term term)
        {
            term.Courses.Add(course);
            //add course into database  
        }

        public static void UpdateCourse(Course course, Term term)
        {
            //Just need to update the database here
        }

        public static void DeleteCourse(Course course, Term term)
        {
            term.Courses.Remove(course);
            //remove course from database
        }

        public static void CreateAssessment(Assessment assessment, Course course)
        {
            course.Assessments.Add(assessment);
            //add assessment into database
        }

        public static void UpdateAssessment(Assessment assessment, Course course)
        {
            //Just need to update the database here
        }

        public static void DeleteAssessment(Assessment assessment, Course course)
        {
            course.Assessments.Remove(assessment);
            //delete assessment from database
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^\(?[\d]{3}\)?[\s-]?[\d]{3}[\s-]?[\d]{4}$").Success;
        }

        public static string FormatDate(DateTime start, DateTime end)
        {
            return start.ToString("MMMM dd, yyyy") + " to " + end.ToString("MMMM dd, yyyy");
        }

        public static string TitleLimitor(string title, int maxLengeth)
        {
            if (title.Length > maxLengeth)
                return title.Substring(0, maxLengeth) + "...";
            return title;
        }

        public static CourseStatus ConvertCourseStatus(string status)
        {
            switch(status.ToLower())
            {
                case ("new"):
                    return CourseStatus.New;
                    break;
                case ("in-progress"):
                    return CourseStatus.Inprogress;
                    break;
                case ("completed"):
                    return CourseStatus.Completed;
                    break;
                case ("failed"):
                    return CourseStatus.Failed;
                    break;
                default:
                    return CourseStatus.New;
            }
        }

    }
}
