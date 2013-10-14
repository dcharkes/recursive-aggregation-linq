using System;
using System.Collections.Generic;
using System.Linq;

namespace recursive_aggregation_linq.Model
{
    class Submission
    {
        private String data;
        private Student student;
        private Assignment assignment;

        public Submission(String d, Student s, Assignment a)
        {
            data = d;
            student = s;
            assignment = a;
            s.addSubmission(this);
            a.addSubmission(this);
        }
    }
}
