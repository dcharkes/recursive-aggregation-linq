using System;
using System.Collections.Generic;
using System.Linq;

namespace recursive_aggregation_linq.Model
{
    class Assignment
    {
        private Unit unit;

        public Assignment(Unit u)
        {
            unit = u;
            submissions = new Dictionary<Student, Submission>();
            u.addAssignment(this);
        }

        private Dictionary<Student, Submission> submissions;
        public IDictionary<Student, Submission> Submissions { get { return submissions; } }
        public void addSubmission(Submission s)
        {
            submissions.Add(s.student, s);
        }

        public double MeanGrade { 
            get {
                return submissions.Values.Average(s => s.Grade);
            } 
        }

    }
}
