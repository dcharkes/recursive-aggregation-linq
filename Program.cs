using recursive_aggregation_linq.Model;
using System;
using System.Diagnostics;
using System.Linq;

namespace recursive_aggregation_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit root = DataGenerator.DataGenerator.generateDataStructure();

            Console.WriteLine("Assignments: " + root.AssignmentCount);
            Console.WriteLine("Submissions: " + root.SubmissionCount);

            Stopwatch st = new Stopwatch();
            st.Start();
            double meanGrade = root.MeanGrade;
            st.Stop();
            Console.WriteLine("Mean grade: {0} {1}ms",meanGrade,st.ElapsedMilliseconds);

            Student student = Student.allStudents.First(i => true);
            st.Reset();
            st.Start();
            double studentMeanGrade = root.MeanGradeStudent(student);
            st.Stop();
            Console.WriteLine("Student {0} has mean grade: {1} {2}ms", student.Id, meanGrade, st.ElapsedMilliseconds);

            st.Reset();
            st.Start();
            foreach (Student s in Student.allStudents)
            {
                root.MeanGradeStudent(s);
            }
            st.Stop();

            Console.WriteLine("All student mean grades {0}ms", st.ElapsedMilliseconds);
            Console.WriteLine("Total grade calculations: {0}", Submission.GradeCalculations);
            Console.ReadKey();
        }
    }
}
