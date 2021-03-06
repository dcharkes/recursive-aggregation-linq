﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace recursive_aggregation_linq.Model
{
    class Submission
    {
        private String data;
        public Student student { get; private set; }
        private Assignment assignment;
        public static int GradeCalculations { get; private set; }

        public Submission(String d, Student s, Assignment a)
        {
            data = d;
            student = s;
            assignment = a;
            s.addSubmission(this);
            a.addSubmission(this);
        }

        public double Grade
        {
            get
            {
                GradeCalculations++;
                return Double.Parse(data.Substring(10)) / 10 % 10;
            }
        }
    }
}
