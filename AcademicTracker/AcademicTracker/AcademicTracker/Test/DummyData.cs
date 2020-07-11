using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AcademicTracker.Model;

namespace AcademicTracker.Test
{
    public static class DummyData
    {
        public static Term Generate(string termName)
        {
            Term term = new Term(termName, DateTime.Now, DateTime.Now.AddDays(1));

            Course course = new Course();
            course.Title = "C971 - Mobile Application Development Using C#";
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(1);
            course.InstructorName = "Wes Miller";
            course.InstructorPhone = "(888) 888-8888";
            course.InstructorEmail = "wbmill48@wgu.edu";
            course.Status = CourseStatus.New;
            course.Notes = "";

            Assessment assessment = new Assessment("Performance Assessment: Mobile Application Development Using C# - LAP1", AssessmentType.Peformance);
            assessment.StartDate = DateTime.Now;
            assessment.EndDate = DateTime.Now.AddDays(1);

            course.Assessments.Add(assessment);
            term.Courses.Add(course);

            course = new Course();
            course.Title = "C191 - Operating Systems for Programmers";
            course.StartDate = DateTime.Now;
            course.EndDate = DateTime.Now.AddDays(1);
            course.InstructorName = "Wes Miller";
            course.InstructorPhone = "(888) 888-8888";
            course.InstructorEmail = "wbmill48@wgu.edu";
            course.Status = CourseStatus.Completed;
            course.Notes = "";

            assessment = new Assessment("Objective Assessment: Operating Systems for Programmers - PAP1", AssessmentType.Peformance);
            assessment.StartDate = DateTime.Now;
            assessment.EndDate = DateTime.Now.AddDays(1);

            course.Assessments.Add(assessment);
            term.Courses.Add(course);

            return term;
        }
    }
}
