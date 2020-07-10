using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    public class Assessment
    {
        public string Name { get; set; }
        public AssessmentType Type { get; set; }
        public AssessmentStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Assessment(string name, AssessmentType type, AssessmentStatus status = AssessmentStatus.New)
        {
            Name = name;
            Type = type;
            Status = status;
        }
    }

    public enum AssessmentType
    {
        Objective = 0,
        Peformance = 1
    }

    public enum AssessmentStatus
    {
        New    = 0,
        Passed = 1,
        Failed = 2
    }
}
