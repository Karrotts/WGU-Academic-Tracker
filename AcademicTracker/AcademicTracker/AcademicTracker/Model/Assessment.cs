using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker.Model
{
    public class Assessment
    {
        string Name { get; set; }
        AssessmentType Type { get; set; }
        AssessmentStatus Status { get; set; }

        Assessment(string name, AssessmentType type, AssessmentStatus status = AssessmentStatus.New)
        {
            this.Name = name;
            this.Type = type;
            this.Status = status;
        }
    }

    internal enum AssessmentType
    {
        Objective = 0,
        Peformance = 1
    }

    internal enum AssessmentStatus
    {
        New    = 0,
        Passed = 1,
        Failed = 2
    }
}
