using System;
using System.Collections.Generic;
using System.Linq;

namespace recursive_aggregation_linq.Model
{
    class Student
    {
        public static HashSet<Student> allStudents;
        private static int nextId = 1;
        private int id { get; set; }


        public Student()
        {
            id = nextId++;
            submissions = new List<Submission>();

            if (allStudents == null)
                allStudents = new HashSet<Student>();
            allStudents.Add(this);
        }

        private List<Submission> submissions;
        public IEnumerable<Submission> Submissions { get { return submissions.AsReadOnly(); } }
        public void addSubmission(Submission s)
        {
            submissions.Add(s);
        }
    }
}
