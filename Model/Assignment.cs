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
            submissions = new List<Submission>();
            u.addAssignment(this);
        }

        private List<Submission> submissions;
        public IEnumerable<Submission> Submissions { get { return submissions.AsReadOnly(); } }
        public void addSubmission(Submission s)
        {
            submissions.Add(s);
        }

    }
}
