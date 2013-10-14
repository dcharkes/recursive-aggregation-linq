using System;
using System.Collections.Generic;
using System.Linq;

namespace recursive_aggregation_linq.Model
{
    class Unit
    {
        private Unit parentUnit;

        public Unit()
        {
            childUnits = new List<Unit>();
            assignments = new List<Assignment>();
        }
        public Unit(Unit parent)
        {
            childUnits = new List<Unit>();
            assignments = new List<Assignment>();
            parentUnit = parent;
            parent.addUnit(this);
        }

        private List<Unit> childUnits;
        public IEnumerable<Unit> ChildUnits { get { return childUnits.AsReadOnly(); } }
        public void addUnit(Unit u)
        {
            childUnits.Add(u);
        }

        private List<Assignment> assignments;
        public IEnumerable<Assignment> Assignments { get { return assignments.AsReadOnly(); } }
        public void addAssignment(Assignment a)
        {
            assignments.Add(a);
        }

        public double MeanGrade
        {
            get
            {
                if (assignments.Count > 0)
                    return assignments.Average(a => a.MeanGrade);
                else if (childUnits.Count > 0)
                    return childUnits.Average(u => u.MeanGrade);
                else
                    return 0.0;
            }
        }

        public double MeanGradeStudent(Student s)
        {
            if (assignments.Count > 0)
                return assignments.Average(a => a.Submissions[s].Grade);
            else if (childUnits.Count > 0)
                return childUnits.Average(u => u.MeanGradeStudent(s));
            else
                return 0.0;
        }

        public int AssignmentCount
        {
            get
            {
                return assignments.Count + childUnits.Sum(u => u.AssignmentCount);
            }
        }

        public int SubmissionCount
        {
            get
            {
                return assignments.Sum(a => a.Submissions.Count()) + childUnits.Sum(u => u.SubmissionCount);
            }
        }
    }
}
