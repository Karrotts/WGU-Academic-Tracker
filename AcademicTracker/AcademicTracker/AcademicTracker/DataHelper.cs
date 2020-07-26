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
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "wgus.db3")))
            {
                //On first load
                connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "wgus.db3"));
            }
            else
            {
                connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "wgus.db3"));
            }
            await connection.CreateTableAsync<TermData>();
            await connection.CreateTableAsync<CourseData>();
            await connection.CreateTableAsync<AssessmentData>();
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

                var coursesData = from data in connection.Table<CourseData>()
                                  where data.term_id == termData.id
                                  select data;

                foreach(CourseData courseData in await coursesData.ToListAsync())
                {
                    Course course = new Course();
                    course.ID = courseData.id;
                    course.TermID = courseData.term_id;
                    course.Title = courseData.title;
                    course.StartDate = courseData.start_date;
                    course.EndDate = courseData.end_date;
                    course.Notifications = courseData.notifications;
                    course.Status = ConvertCourseStatus(courseData.status);
                    course.InstructorName = courseData.instructor_name;
                    course.InstructorPhone = courseData.instructor_phone;
                    course.InstructorEmail = courseData.instructor_email;
                    course.Notes = courseData.notes;

                    var assessmentsData = from data in connection.Table<AssessmentData>()
                                         where data.course_id == courseData.id
                                         select data;

                    foreach(AssessmentData assessmentData in await assessmentsData.ToListAsync())
                    {
                        Assessment assessment = new Assessment(assessmentData.name, ConvertAssessmentType(assessmentData.type), ConvertAssessmentStatus(assessmentData.status));
                        Console.WriteLine(assessmentData.id);
                        assessment.ID = assessmentData.id;
                        assessment.CourseID = assessmentData.course_id;
                        assessment.Notifications = assessmentData.notifications;
                        assessment.StartDate = assessmentData.start_date;
                        assessment.EndDate = assessmentData.end_date;

                        course.Assessments.Add(assessment);
                    }

                    term.Courses.Add(course);
                }

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

        public async static void UpdateTerm(Term term)
        {
            TermData termData = new TermData();
            termData.id = term.ID;
            termData.name = term.Name;
            termData.start_date = term.StartDate;
            termData.end_date = term.EndDate;
            await connection.UpdateAsync(termData);
        }

        public async static void DeleteTerm(Term term)
        {
            DataStore.Remove(term);
            await connection.ExecuteAsync("DELETE FROM terms WHERE id = " + term.ID);
        }

        public async static void CreateCourse(Course course, Term term)
        {
            CourseData courseData = new CourseData();
            courseData.term_id = term.ID;
            courseData.title = course.Title;
            courseData.start_date = course.StartDate;
            courseData.end_date = course.EndDate;
            courseData.notifications = course.Notifications;
            courseData.status = course.Status.ToString();
            courseData.instructor_name = course.InstructorName;
            courseData.instructor_email = course.InstructorEmail;
            courseData.instructor_phone = course.InstructorPhone;
            courseData.notes = course.Notes;

            await connection.InsertAsync(courseData).ContinueWith((t) =>
            {
                Console.WriteLine("New Course ID: {0}", courseData.id);
                course.ID = courseData.id;
            });

            term.Courses.Add(course);
        }

        public async static void UpdateCourse(Course course, Term term)
        {
            CourseData courseData = new CourseData();
            courseData.id = course.ID;
            courseData.term_id = term.ID;
            courseData.title = course.Title;
            courseData.start_date = course.StartDate;
            courseData.end_date = course.EndDate;
            courseData.notifications = course.Notifications;
            courseData.status = course.Status.ToString();
            courseData.instructor_name = course.InstructorName;
            courseData.instructor_email = course.InstructorEmail;
            courseData.instructor_phone = course.InstructorPhone;
            courseData.notes = course.Notes;
            await connection.UpdateAsync(courseData);
        }

        public async static void DeleteCourse(Course course, Term term)
        {
            term.Courses.Remove(course);
            await connection.ExecuteAsync("DELETE FROM courses WHERE id = " + course.ID);
        }

        public async static void CreateAssessment(Assessment assessment, Course course)
        {
            AssessmentData assessmentData = new AssessmentData();
            assessmentData.course_id = course.ID;
            assessmentData.name = assessment.Name;
            assessmentData.start_date = assessment.StartDate;
            assessmentData.end_date = assessment.EndDate;
            assessmentData.notifications = assessment.Notifications;
            assessmentData.status = assessment.Status.ToString();
            assessmentData.type = assessment.Type.ToString();

            await connection.InsertAsync(assessmentData).ContinueWith((t) =>
            {
                Console.WriteLine("New Assessment ID: {0}", assessmentData.id);
                assessment.ID = assessmentData.id;
            });

            course.Assessments.Add(assessment);
        }

        public async static void UpdateAssessment(Assessment assessment, Course course)
        {
            AssessmentData assessmentData = new AssessmentData();
            assessmentData.id = assessment.ID;
            assessmentData.course_id = course.ID;
            assessmentData.name = assessment.Name;
            assessmentData.start_date = assessment.StartDate;
            assessmentData.end_date = assessment.EndDate;
            assessmentData.notifications = assessment.Notifications;
            assessmentData.status = assessment.Status.ToString();
            assessmentData.type = assessment.Type.ToString();
            await connection.UpdateAsync(assessmentData);
        }

        public async static void DeleteAssessment(Assessment assessment, Course course)
        {
            course.Assessments.Remove(assessment);
            await connection.ExecuteAsync("DELETE FROM assessments WHERE id = " + assessment.ID);
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
                    return AssessmentType.Performance;
                    break;
                default:
                    return AssessmentType.Objective;
            }
        }

    }
}
