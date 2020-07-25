using AcademicTracker.Model;
using AcademicTracker.Test;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AcademicTracker
{
    public static class DataHelper
    {
        public static ObservableCollection<Term> DataStore = new ObservableCollection<Term>();
        public static SQLiteAsyncConnection connection;

        public async static void Initalize()
        {
            //set connection
            connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "wgu.db3"));
            await connection.CreateTableAsync<TermData>();
            //course data
            //assessment data... ect...
            LoadTerms();

        }

        private async static void LoadTerms()
        {
            var termsData = await connection.Table<TermData>().ToListAsync();
            foreach(TermData termData in termsData)
            {
                Term term = new Term();
                term.ID = termData.id;
                term.Name = termData.name;
                term.StartDate = termData.start_date;
                term.EndDate = termData.end_date;
                DataStore.Add(term);
            }
        }

        public async static void CreateTerm(Term term)
        {
            TermData data = new TermData();
            data.name = term.Name;
            data.start_date = term.StartDate;
            data.end_date = term.EndDate;

            await connection.InsertAsync(data).ContinueWith((t) =>
            {
                Console.WriteLine("New Term ID: {0}", data.id);
                term.ID = data.id;
            });

            DataStore.Add(term);
        }

        public static void UpdateTerm(Term term)
        {
            //Just need to update the database here
        }

        public async static void DeleteTerm(Term term)
        {
            DataStore.Remove(term);
            TermData termData = new TermData();
            termData.id = term.ID;
            Console.WriteLine(term.ID);
            await connection.ExecuteAsync("DELETE FROM terms WHERE id = " + term.ID);
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

        public static AssessmentStatus ConvertAssessmentStatus(string status)
        {
            switch (status.ToLower())
            {
                case ("new"):
                    return AssessmentStatus.New;
                    break;
                case ("passed"):
                    return AssessmentStatus.Passed;
                    break;
                case ("failed"):
                    return AssessmentStatus.Failed;
                    break;
                default:
                    return AssessmentStatus.New;
            }
        }

        public static AssessmentType ConvertAssessmentType(string type)
        {
            switch (type.ToLower())
            {
                case ("objective"):
                    return AssessmentType.Objective;
                    break;
                case ("performance"):
                    return AssessmentType.Peformance;
                    break;
                default:
                    return AssessmentType.Objective;
            }
        }

    }
}
